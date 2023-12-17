using Amazon.DynamoDBv2.DataModel;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.Interfaces;
using RockwellAutomation.Challenge.WebCronScrapping.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.DynamoDb.Repositories
{
    public class WebScrapingJobResultRepository: IWebScrapingJobResultRepository
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public WebScrapingJobResultRepository(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public bool Add(WebScrapingJobResult webScrapingJobResult)
        {
            return _dynamoDbContext.SaveAsync(webScrapingJobResult).IsCompletedSuccessfully;
        }

        public bool Delete(string jobId)
        {
            return _dynamoDbContext.DeleteAsync(jobId).IsCompletedSuccessfully;
        }

        public WebScrapingJobResult Get(string jobId)
        {
            return _dynamoDbContext.QueryAsync<WebScrapingJobResult>(jobId)
                .GetRemainingAsync().Result.FirstOrDefault();
        }

        public List<WebScrapingJobResult> GetAll()
        {
            return _dynamoDbContext.ScanAsync<WebScrapingJobResult>(null)
                .GetRemainingAsync().Result;
        }
    }
}
