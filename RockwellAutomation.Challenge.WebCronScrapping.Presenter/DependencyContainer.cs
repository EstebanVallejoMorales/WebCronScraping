using Microsoft.Extensions.DependencyInjection;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.JobManagement;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.Presenter.WebScrapingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Presenter
{
    public static class DependencyContainer
    {
        public static IServiceCollection DependencyPresenter(this IServiceCollection services)
        {
            services.AddScoped<IScheduleWebScrapingOutputPort, ScheduleWebScrapingPresenter>();
            services.AddScoped<IGenerateJobOutputPort, GenerateJobPresenter>();
            return services;
        } 
    }
}
