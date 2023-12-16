using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult
{
    public interface IGenerateJobOutputPort
    {
        void Handler(WebScrapingResultDto webScrapingResultDto);
    }
}
