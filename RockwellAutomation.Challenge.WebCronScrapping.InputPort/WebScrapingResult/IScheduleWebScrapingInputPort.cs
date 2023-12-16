namespace RockwellAutomation.Challenge.WebCronScrapping.InputPort.WebScrapingResult
{
    public interface IScheduleWebScrapingInputPort
    {
        Task Handler(string url);
    }
}
