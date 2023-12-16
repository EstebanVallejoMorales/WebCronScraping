using Amazon.DynamoDBv2.DataModel;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.Interfaces;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.DynamoDB.Repository
{
    public class WebScrapingResultJobRepository : IWebScrapingResultJobRepository
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public WebScrapingResultJobRepository(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public bool Add(WebScrapingResultJob webScrapingResultJob)
        {
            return _dynamoDBContext.SaveAsync(webScrapingResultJob).IsCompletedSuccessfully;
        }

        public bool Delete(string jobId)
        {
            return _dynamoDBContext.DeleteAsync(jobId).IsCompletedSuccessfully;
        }

        public WebScrapingResultJob Get(string jobId)
        {
            return _dynamoDBContext.QueryAsync<WebScrapingResultJob>(jobId).GetRemainingAsync().Result.FirstOrDefault();
        }

        public List<WebScrapingResultJob> GetAll()
        {
            return _dynamoDBContext.ScanAsync<WebScrapingResultJob>(new List<ScanCondition>()).GetRemainingAsync().Result;
        }
    }
}
