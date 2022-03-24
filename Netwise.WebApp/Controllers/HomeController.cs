using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Netwise.Infrastructure.Services.FileHandler;
using Netwise.Infrastructure.Services.WebClient;

namespace Netwise.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebClient client;
        private readonly IFileHandler fileHandler;

        public HomeController(IWebClient client, IFileHandler fileHandler)
        {
            this.client = client;
            this.fileHandler = fileHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendRequest()
        {
            return View();
        }
    }
}
