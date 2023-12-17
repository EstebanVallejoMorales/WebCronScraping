using Microsoft.AspNetCore.Mvc;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.Interactor.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.Presenter;

namespace RockwellAutomation.Challenge.WebCronScrapping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebCronScrapingController : Controller
    {
        private readonly ILogger<WebCronScrapingController> _logger;
        private readonly IScheduleWebScrapingInputPort _scheduleWebScrapingInputPort;
        private readonly IScheduleWebScrapingOutputPort _scheduleWebScrapingOutputPort;
        private readonly IGenerateJobInputPort _generateJobInputPort;
        private readonly IGenerateJobOutputPort _generateJobOutputPort;
        private readonly IGetAllWebScrapingJobResultInputPort _getAllWebScrapingJobResultInputPort;
        private readonly IGetAllWebScrapingJobResultOutputPort _getAllWebScrapingJobResultOutputPort;
        
        public WebCronScrapingController(ILogger<WebCronScrapingController> logger,
            IScheduleWebScrapingInputPort scheduleWebScrapingInputPort,
            IGenerateJobInputPort generateJobInputPort,
            IGenerateJobOutputPort generateJobOutputPort,
            IScheduleWebScrapingOutputPort scheduleWebScrapingOutputPort,
            IGetAllWebScrapingJobResultInputPort getAllWebScraìngJobResultInputPort,
            IGetAllWebScrapingJobResultOutputPort getAllWebScraìngJobResultOutputPort)
        {
            _logger = logger;
            _scheduleWebScrapingInputPort = scheduleWebScrapingInputPort;
            _scheduleWebScrapingOutputPort = scheduleWebScrapingOutputPort;
            _generateJobInputPort = generateJobInputPort;
            _generateJobOutputPort = generateJobOutputPort;
            _getAllWebScrapingJobResultInputPort = getAllWebScraìngJobResultInputPort;
            _getAllWebScrapingJobResultOutputPort = getAllWebScraìngJobResultOutputPort;
        }

        [HttpGet("GetWebCronScrapping")]
        public WebScrapingResultDto GetWebCronScrapping(string url)
        {
            _scheduleWebScrapingInputPort.Handler(url).Wait();
            return ((IPresenter<WebScrapingResultDto>)_scheduleWebScrapingOutputPort).Content;

        }

        [HttpGet("GetAllWebScraìngJobResult")]
        public List<WebScrapingJobResultDto> GetAllWebScraìngJobResult()
        {
            _getAllWebScrapingJobResultInputPort.Handler().Wait();
            return ((IPresenter<List<WebScrapingJobResultDto>>)_getAllWebScrapingJobResultOutputPort).Content;

        }

        [HttpPost("ScheduleWebCronScrapping")]
        public WebScrapingResultDto ScheduleWebCronScrapping(
            [FromBody] WebScrapingScheduleRequestDto webScrapingScheduleRequestDto)
        {
            _generateJobInputPort.Handler(webScrapingScheduleRequestDto.Url,
                webScrapingScheduleRequestDto.Cron).Wait();
            return ((IPresenter<WebScrapingResultDto>)_generateJobOutputPort).Content;
        }
    }
}
