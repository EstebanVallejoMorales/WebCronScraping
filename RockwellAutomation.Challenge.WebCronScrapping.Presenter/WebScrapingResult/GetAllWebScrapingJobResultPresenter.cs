using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Presenter.WebScrapingResult
{
    public class GetAllWebScrapingJobResultPresenter : IGetAllWebScrapingJobResultOutputPort, 
        IPresenter<List<WebScrapingJobResultDto>>
    {
        public List<WebScrapingJobResultDto> Content { get; private set; }

        public void Handler(List<WebScrapingJobResultDto> webScrapingJobResults)
        {
            Content = webScrapingJobResults;
        }
    }
}
