using PuppeteerSharp;
using Quartz;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.Interactor.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Quartz.Logging.OperationName;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor.JobManagement
{
    public class GenerateJobInteractor : IGenerateJobInputPort
    {
        private readonly IGenerateJobOutputPort _generateJobOutputPort;
        private readonly ISchedulerFactory _schedulerFactory;

        public GenerateJobInteractor(IGenerateJobOutputPort generateJobOutputPort,
            ISchedulerFactory schedulerFactory)
        {
            _generateJobOutputPort = generateJobOutputPort;
            _schedulerFactory = schedulerFactory;
        }

        public async Task Handler(string url, string cronExpresion)
        {
            WebScrapingResultDto resultDto = new WebScrapingResultDto();

            try
            {
                var jobDataMap = new JobDataMap { { "Url", url } };
                string guidId = Guid.NewGuid().ToString();

                IScheduler scheduler = await _schedulerFactory.GetScheduler();
                await scheduler.Start();

                IJobDetail jobDetail = JobBuilder.Create<WebScrapingJob>()
                .WithIdentity(guidId, "group1")
                .UsingJobData(jobDataMap)
                .Build();

                ITrigger cronTrigger = TriggerBuilder.Create()
                    .WithIdentity(guidId + "-Trigger", "group1")
                    .StartNow()
                    .WithCronSchedule(cronExpresion)
                    //.WithSimpleSchedule(x => x
                    //.WithIntervalInSeconds(10)
                    //.RepeatForever())
                    .Build();

                await scheduler.ScheduleJob(jobDetail, cronTrigger);

                resultDto.Message = $"Job with ID: {guidId} successfuly created. You can ask for the result using this ID.";
                _generateJobOutputPort.Handler(resultDto);
            }
            catch (Exception ex)
            {
                resultDto.Message = $"There was an error trying to create the job: {ex.Message}";
                _generateJobOutputPort.Handler(resultDto);
            }

        }
    }
}
