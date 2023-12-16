using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS
{
    public class WebScrapingResultJob
    {
        public string JobId { get; set; }
        public List<string> Headers { get; set; }
        public DateTime Date { get; set; }
    }
}
