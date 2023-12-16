using Microsoft.AspNetCore.Mvc;

namespace RockwellAutomation.Challenge.WebCronScrapping.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
