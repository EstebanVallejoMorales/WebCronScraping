using PuppeteerSharp;
using RockwellAutomation.Challenge.WebCronScrapping.Dto;
using RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult;
using RockwellAutomation.Challenge.WebCronScrapping.OutputPort.WebScrapingResult;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.Interactor.WebScrapingResult
{
    public class ScheduleWebScrapingInteractor : IScheduleWebScrapingInputPort
    {
        private readonly IScheduleWebScrapingOutputPort _scheduleWebScrapingOutputPort;

        public ScheduleWebScrapingInteractor(IScheduleWebScrapingOutputPort scheduleWebScrapingOutputPort)
        {
            _scheduleWebScrapingOutputPort = scheduleWebScrapingOutputPort;
        }

        public async void Handler(string url)
        {
            WebScrapingResultDto resultDto = new WebScrapingResultDto();

            try
            {
                List<string> headers;
                var browserFetcher = new BrowserFetcher();
                string chromiumExecutablePath = "/usr/bin/chromium";
                LaunchOptions launchOptions = new LaunchOptions
                {
                    ExecutablePath = chromiumExecutablePath,
                    Headless = true
                };

                await browserFetcher.DownloadAsync();
                await using var browser = await Puppeteer.LaunchAsync(launchOptions);

                using var page = await browser.NewPageAsync();
                await page.GoToAsync(url);

                //Javascript code to get all h2 header elements
                var result = await page.EvaluateFunctionAsync("() => {" +
                    "const query = document.querySelectorAll('h2');" +
                    "const result = [];" +
                    "for(let i = 0; i < query.length; i++){" +
                    "   result.push(query[i].innerHTML);" +
                    "}" +
                    "return result;" +
                    "}");

                if (result != null && result.Any())
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }

                    headers = result.ToObject<List<string>>();
                    resultDto.Headers = headers ?? new List<string>();
                    resultDto.Message = "Web Scraping successful";
                }
                else
                {
                    resultDto.Message = "Web Scraping failed";
                    resultDto.Headers = new List<string>();
                }

                _scheduleWebScrapingOutputPort.Handler(resultDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                resultDto = new WebScrapingResultDto
                {
                    Headers = new List<string>(),
                    Message = "It was not possible to extract the requested elements."
                };
                _scheduleWebScrapingOutputPort.Handler(resultDto);
            }
        }
    }
}
