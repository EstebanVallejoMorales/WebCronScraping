using RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Entities.Interfaces
{
    public interface IWebScrapingJobResultRepository
    {
        bool Add(WebScrapingJobResult webScrapingJobResult);
        bool Delete(string jobId);
        List<WebScrapingJobResult> GetAll();
        WebScrapingJobResult Get(string jobId);
    }
}
