using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.JobManagement;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor.JobManagement
{
    public class UnescheduleJobInteractor : IUnescheduleJobInputPort
    {
        private readonly IUnescheduleJobOutputPort _unescheduleJobOutputPort;
        private readonly ISchedulerFactory _schedulerFactory;

        public UnescheduleJobInteractor(IUnescheduleJobOutputPort unescheduleJobOutputPort,
            ISchedulerFactory schedulerFactory)
        {
            _unescheduleJobOutputPort = unescheduleJobOutputPort;
            _schedulerFactory = schedulerFactory;
        }

        public async Task Handler(string jobId)
        {
            WebScrapingResultDto resultDto = new WebScrapingResultDto();
            try
            {
                var jobKey = new JobKey(jobId);

                IScheduler scheduler = await _schedulerFactory.GetScheduler();

                await scheduler.UnscheduleJob(new TriggerKey(jobId + "-Trigger"));
                await scheduler.DeleteJob(jobKey);
            }
            catch (Exception ex)
            {
                resultDto.Message = $"There was an error trying to delete the job with ID: {jobId}: {ex.Message}";
                _unescheduleJobOutputPort.Handler(resultDto);
            }
            
        }
    }
}
