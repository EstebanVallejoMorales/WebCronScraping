using RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Entities.Interfaces
{
    public interface IWebScrapingResultJobRepository
    {
        bool Add(WebScrapingResultJob webScrapingResultJob);
        bool Delete(string jobId);
        List<WebScrapingResultJob> GetAll();
        WebScrapingResultJob Get(string jobId);
        
    }
}
