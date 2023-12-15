using PuppeteerSharp;
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
    public class ScheduleWebScrapingInputPort: IScheduleWebScrapingInputPort
    {
        private readonly IScheduleWebScrapingOutputPort _scheduleWebScrapingOutputPort;

        public ScheduleWebScrapingInputPort(IScheduleWebScrapingOutputPort scheduleWebScrapingOutputPort)
        {
            _scheduleWebScrapingOutputPort = scheduleWebScrapingOutputPort;
        }

        public async void UseWebScrapingDemo(string url)
        {
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

            List<string> headers = new List<string>();

        }
    }
}
