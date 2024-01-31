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

            string accessKey = string.Empty;
            string secretKey = string.Empty;

            try
            {
                accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY") ?? string.Empty;
                secretKey = Environment.GetEnvironmentVariable("SECRET_KEY") ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            AmazonDynamoDBClient client;

            if (accessKey != string.Empty && secretKey != string.Empty)
            {
                var credentials = new BasicAWSCredentials(accessKey, secretKey);
                client = new AmazonDynamoDBClient(credentials, config);
            }
            else
            {
                client = new AmazonDynamoDBClient(config);
            }

            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

            return services;
        }

    }
}
