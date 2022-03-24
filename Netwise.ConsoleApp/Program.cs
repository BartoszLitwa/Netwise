using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netwise.Domain.Domain;
using Netwise.Infrastructure.Services.FileHandler;
using Netwise.Infrastructure.Services.WebClient;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Netwise.ConsoleApp
{
    public class Program
    {
        private readonly IWebClient client;
        private readonly IFileHandler fileHandler;

        public Program(IWebClient client, IFileHandler fileHandler)
        {
            this.client = client;
            this.fileHandler = fileHandler;
        }

        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Run our program
            await host.Services
                .GetRequiredService<Program>()
                .Run(args);
        }

        public async Task Run(string[] args)
        {
            // Setup Services
            Setup();

            Console.WriteLine("Prosze wpisac 'y', aby wyslac request,\n 'x' aby zakonczyc program,\n 'r' aby odczytac zawartosc pliku");
            var key = Console.ReadLine()[0];
            while (key != 'x')
            {
                if(key == 'y')
                {
                    await HandleRequest("/fact");
                }
                else
                {
                    Console.WriteLine("Obecnie zapisane: ");
                    var lines = await fileHandler.ReadAllFromFile();
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }

                // Read and take first letter
                key = Console.ReadLine()[0];
            }
        }

        private async Task HandleRequest(string endpoint)
        {
            var resp = await client.GetJsonResponse<FactResponse>(endpoint);
            await fileHandler.AppendToFile($"{resp.Length}: {resp.Fact}");
            Console.WriteLine($"{resp.Length}: {resp.Fact}");
        }

        private void Setup()
        {
            client.SetupClient("https://catfact.ninja");
            fileHandler.SetupClient(Directory.GetCurrentDirectory() + "/Responses.txt");
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    // Instead of Using AddHttpClient as in WebApp we have to "create" httpclient
                    // because our WebClient accepts it in ctor
                    services.AddSingleton<HttpClient>();
                    services.AddSingleton<IWebClient, WebClient>();
                    services.AddSingleton<IFileHandler, FileHandler>();
                });
        }
    }
}
