using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.GenerateJob;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.Interactor.GenerateJob;
using RockwellAutomation.Challenge.WebCronScrapping.Interactor.JobUtils;
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
            services.AddScoped<IScheduleWebScrapingInputPort, ScheduleWebScrapingInteractor>();
            services.AddScoped<IGenerateJobInputPort, GenerateJobInteractor>();
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            return services;
        }
    }
}
