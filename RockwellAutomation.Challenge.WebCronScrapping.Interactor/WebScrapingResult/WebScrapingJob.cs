using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using PuppeteerSharp;
using Quartz;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor.WebScrapingResult
{
    public class WebScrapingJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            /*Note: This class can't have constructor to inject dependencies 
             * because Quartz doesn't allow it. Clean architecture could be broken here until 
             * Quartz fix the restriction. _Esteban V.
            */

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

            DynamoDBContext dynamoDBContext = new DynamoDBContext(client);

            string url = context.MergedJobDataMap.GetString("Url");
            string jobId = context.MergedJobDataMap.GetString("JobId");
            WebScrapingResultDto resultDto = await WebScraper.ExecuteWebSCraping(url);

            //Save job result in DynamoDB
            WebScrapingJobResult webScrapingJobResult = new WebScrapingJobResult
            {
                Headers = string.Join(Environment.NewLine, resultDto.Headers),
                JobId = jobId,
                ExecutionDateInfo = $"Executed at {DateTime.UtcNow.AddHours(-5)}"
            };
            try
            {
                await dynamoDBContext.SaveAsync(webScrapingJobResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
