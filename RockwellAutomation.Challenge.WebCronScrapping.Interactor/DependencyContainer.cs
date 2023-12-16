using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.Interactor.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.Interactor.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor
{
    public static class DependencyContainer
    {
        public static IServiceCollection DependencyInteractor(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddScoped<IScheduleWebScrapingInputPort, ScheduleWebScrapingInteractor>();
            services.AddScoped<IGenerateJobInputPort, GenerateJobInteractor>();
            services.AddScoped<IJob, WebScrapingJob>();
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
            });
            services.AddQuartzHostedService(opt =>
            {
                opt.WaitForJobsToComplete = true;
            });

            return services;
        }
    }
}
