using Microsoft.Extensions.DependencyInjection;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult;
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
            return services;
        }
    }
}
