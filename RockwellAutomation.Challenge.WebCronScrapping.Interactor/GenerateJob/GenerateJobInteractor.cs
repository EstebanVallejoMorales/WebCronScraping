using Quartz;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.GenerateJob;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor.GenerateJob
{
    public class GenerateJobInteractor : IJob, IGenerateJobInputPort
    {
        private readonly IGenerateJobOutputPort _generateJobOutputPort;
        private readonly IScheduleWebScrapingInputPort _scheduleWebScrapingInputPort;

        public GenerateJobInteractor(IGenerateJobOutputPort generateJobOutputPort, IScheduleWebScrapingInputPort _scheduleWebScrapingInputPort)
        {
            _generateJobOutputPort = generateJobOutputPort;
            _scheduleWebScrapingInputPort = _scheduleWebScrapingInputPort;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }

        public Task Handler(string url, string cronExpresion)
        {
            //JobMetaDataDto jobMetaDataDto = new JobMetaDataDto 
            //{
            //    CronExpresion = cronExpresion
            //};

            //Call Execute
            return Task.CompletedTask;
        }
    }
}
