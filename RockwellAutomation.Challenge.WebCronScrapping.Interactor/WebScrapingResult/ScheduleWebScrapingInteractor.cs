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
                
        public async Task Handler(string url)
        {
            WebScrapingResultDto resultDto = await WebScraper.ExecuteWebSCraping(url);
            _scheduleWebScrapingOutputPort.Handler(resultDto);
        }
    }
}
