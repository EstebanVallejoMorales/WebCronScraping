using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor.JobUtils
{
    public class AppScheduler : IHostedService
    {
        public IScheduler Scheduler { get; set; }
        private readonly IJobFactory _jobFactory;
        private readonly JobMetaDataDto _jobMetaDataDto;
        private readonly ISchedulerFactory _schedulerFactory;

        public AppScheduler(IJobFactory jobFactory, JobMetaDataDto jobMetaDataDto, 
            ISchedulerFactory schedulerFactory)
        {
            _jobFactory = jobFactory;
            _jobMetaDataDto = jobMetaDataDto;
            _schedulerFactory = schedulerFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //Create Scheduler
            Scheduler = await _schedulerFactory.GetScheduler();
            Scheduler.JobFactory = _jobFactory;

            //Create Job
            IJobDetail jobDetail = CreateJob(_jobMetaDataDto);

            //Create Trigger
            ITrigger trigger = CreateTrigger(_jobMetaDataDto);

            //Schedule Job
            await Scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);

            //Start the Scheduler
            await Scheduler.Start(cancellationToken);
        }

        private ITrigger CreateTrigger(JobMetaDataDto jobMetaDataDto)
        {
            return TriggerBuilder.Create()
                .WithIdentity(jobMetaDataDto.JobId.ToString())
                .WithCronSchedule(jobMetaDataDto.CronExpresion)
                .WithDescription(jobMetaDataDto.JobName)
                .Build();
        }

        private IJobDetail CreateJob(JobMetaDataDto jobMetaDataDto)
        {
            return JobBuilder.Create(jobMetaDataDto.JobType)
                .WithIdentity(jobMetaDataDto.JobId.ToString())
                .WithDescription(jobMetaDataDto.JobName)
                .Build();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
