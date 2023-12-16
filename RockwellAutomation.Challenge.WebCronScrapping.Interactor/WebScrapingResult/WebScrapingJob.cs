using PuppeteerSharp;
using Quartz;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor.WebScrapingResult
{
    public class WebScrapingJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            string url = context.MergedJobDataMap.GetString("Url");

            //await Console.Out.WriteLineAsync($"Greetings from TestJob!, url = {url}");

            await WebScraper.ExecuteWebSCraping(url);
        }
    }
}
