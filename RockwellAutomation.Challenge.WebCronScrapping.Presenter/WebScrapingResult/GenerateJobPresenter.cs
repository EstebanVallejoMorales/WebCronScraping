using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Presenter.WebScrapingResult
{
    public class GenerateJobPresenter : IGenerateJobOutputPort, IPresenter<WebScrapingResultDto>
    {
        public WebScrapingResultDto Content { get; private set; }

        public void Handler(WebScrapingResultDto webScrapingResultDto)
        {
            Content = webScrapingResultDto;
        }
    }
}
