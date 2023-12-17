using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.OutputPort.JobManagement
{
    public interface IGetAllWebScrapingJobResultOutputPort
    {
        void Handler(List<WebScrapingJobResultDto> webScrapingJobResults);
    }
}
