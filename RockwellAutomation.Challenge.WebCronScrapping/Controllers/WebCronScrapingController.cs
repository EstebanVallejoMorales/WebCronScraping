using Microsoft.AspNetCore.Mvc;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.Presenter;

namespace RockwellAutomation.Challenge.WebCronScrapping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebCronScrapingController : Controller
    {
        private readonly ILogger<WebCronScrapingController> _logger;
        private readonly IScheduleWebScrapingInputPort _scheduleWebScrapingInputPort;
        private readonly IScheduleWebScrapingOutputPort _scheduleWebScrapingOutputPort;

        public WebCronScrapingController(ILogger<WebCronScrapingController> logger, 
            IScheduleWebScrapingInputPort scheduleWebScrapingInputPort,
            IScheduleWebScrapingOutputPort scheduleWebScrapingOutputPort)
        {
            _logger = logger;
            _scheduleWebScrapingInputPort = scheduleWebScrapingInputPort;
            _scheduleWebScrapingOutputPort = scheduleWebScrapingOutputPort;
        }

        [HttpGet(Name = "GetWebCronScrapping")]
        public WebScrapingResultDto GetWebCronScrapping(string url)
        {
            if (url != null)
            {
                _scheduleWebScrapingInputPort.Handler(url).Wait();
                return ((IPresenter<WebScrapingResultDto>)_scheduleWebScrapingOutputPort).Content;
            }

            return null;
        }
    }
}
