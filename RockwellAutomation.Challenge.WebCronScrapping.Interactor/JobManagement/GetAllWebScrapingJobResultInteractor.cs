using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.Interfaces;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.JobManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor.JobManagement
{
    public class GetAllWebScrapingJobResultInteractor : IGetAllWebScrapingJobResultInputPort
    {
        private readonly IGetAllWebScrapingJobResultOutputPort _getAllWebScraìngJobResultOutputPort;
        private readonly IWebScrapingJobResultRepository _webScrapingJobResultRepository;

        public GetAllWebScrapingJobResultInteractor(IGetAllWebScrapingJobResultOutputPort getAllWebScraìngJobResultOutputPort,
            IWebScrapingJobResultRepository webScrapingJobResultRepository)
        {
            _getAllWebScraìngJobResultOutputPort = getAllWebScraìngJobResultOutputPort;
            _webScrapingJobResultRepository = webScrapingJobResultRepository;
        }

        public async Task Handler()
        {
            List<WebScrapingJobResultDto> webScrapingJobResultsDto = new List<WebScrapingJobResultDto>();

            try
            {
                var webScrapingJobResults = _webScrapingJobResultRepository.GetAll();

                //Manual mapping
                foreach (var item in webScrapingJobResults)
                {
                    webScrapingJobResultsDto.Add(new WebScrapingJobResultDto
                    {
                        Headers = item.Headers, 
                        JobId = item.JobId,
                        ExecutionDateInfo = item.ExecutionDateInfo,
                    });
                }

                _getAllWebScraìngJobResultOutputPort.Handler(webScrapingJobResultsDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _getAllWebScraìngJobResultOutputPort.Handler(webScrapingJobResultsDto);
            }
        }
    }
}
