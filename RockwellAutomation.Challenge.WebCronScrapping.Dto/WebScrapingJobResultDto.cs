﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Dto
{
    public class WebScrapingJobResultDto
    {
        public string JobId { get; set; }
        public string Headers { get; set; }
        public string ExecutionDateInfo { get; set; }
    }
}
