using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Netwise.Domain.Domain;
using Netwise.Infrastructure.Services.FileHandler;
using Netwise.Infrastructure.Services.WebClient;
using System.IO;
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

            this.client.SetupClient("https://catfact.ninja");
        }
        public async Task<IActionResult> Index()
        {
            return View("Index");
        }

        public async Task<IActionResult> SendRequest()
        {
            var resp = await client.GetJsonResponse<FactResponse>("/fact");
            await fileHandler.AppendToFile($"{resp.Length}: {resp.Fact}");

            return View("SendRequest", resp);
        }

        public async Task<IActionResult> ReadFromFile()
        {
            var lines = await fileHandler.ReadAllFromFile();

            return View("ReadFromFile", lines);
        }
    }
}
