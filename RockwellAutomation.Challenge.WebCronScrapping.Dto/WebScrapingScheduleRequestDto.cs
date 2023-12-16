using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Dto
{
    public class WebScrapingScheduleRequestDto
    {
        public string Url { get; set; }
        public string Cron { get; set; }
    }
}
