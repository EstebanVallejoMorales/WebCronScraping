using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Dto
{
    public class JobMetaDataDto
    {
        public Guid JobId { get; set; }
        public string JobName { get; }
        public Type JobType { get; set; }
        public string CronExpresion { get; }

        public JobMetaDataDto(Guid jobId, string jobName, Type jobType, string cronExpresion)
        {
            JobId = jobId;
            JobName = jobName;
            JobType = jobType;
            CronExpresion = cronExpresion;
        }

    }
}
