using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Netwise.Infrastructure.Services.FileHandler;
using Netwise.Infrastructure.Services.WebClient;
using System.Threading.Tasks;

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

        public async Task<IActionResult> SendRequest()
        {
            return View("SendRequest");
        }

        public async Task<IActionResult> ReadFromFile()
        {
            return View("ReadFromFile");
        }
    }
}
