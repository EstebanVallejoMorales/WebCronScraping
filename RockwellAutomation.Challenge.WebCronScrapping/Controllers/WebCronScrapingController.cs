using Microsoft.AspNetCore.Mvc;

namespace RockwellAutomation.Challenge.WebCronScrapping.Controllers
{
    public class WebCronScrapingController : Controller
    {
        private readonly ILogger<WebCronScrapingController> _logger;

        public WebCronScrapingController(ILogger<WebCronScrapingController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
