using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netwise.Infrastructure.Services.FileHandler;
using Netwise.Infrastructure.Services.WebClient;
using System;
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
            Console.WriteLine("Hello World");
            Console.ReadLine();
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
