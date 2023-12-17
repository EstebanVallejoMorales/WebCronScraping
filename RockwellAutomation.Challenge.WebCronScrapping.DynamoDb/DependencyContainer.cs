using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using System.Net;

namespace RockwellAutomation.Challenge.WebCronScrapping.DynamoDb
{
    public static class DependencyContainer
    {
        public static IServiceCollection DependencyDynamoDb(this IServiceCollection services)
        {
            //DynamoDb configuration
            var config = new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.USEast1
            };
            //var credentials = new BasicAWSCredentials("", "");
            //var client = new AmazonDynamoDBClient(credentials, config);
            var client = new AmazonDynamoDBClient(config);
            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

            return services;
        }

    }
}
