using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Internal;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RockwellAutomation.Challenge.WebCronScrapping.DynamoDB.Repository;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.DynamoDB
{
    public static class DependencyContainer
    {
        public static IServiceCollection DependencyEF(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IWebScrapingResultJobRepository, WebScrapingResultJobRepository>();
            var config = new AmazonDynamoDBConfig()
            {
                RegionEndpoint = RegionEndpoint.USEast1
            };
            var client = new AmazonDynamoDBClient(config);
            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
            return services;
        }
    }
}
