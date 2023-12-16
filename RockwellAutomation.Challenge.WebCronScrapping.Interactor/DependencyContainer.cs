using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
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
            services.AddSingleton<IDynamoDBContext,DynamoDBContext>();
            var config = new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.USEast1
            };
            var client = new AmazonDynamoDBClient(config);
            services.AddSingleton<IAmazonDynamoDB>(client);
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
