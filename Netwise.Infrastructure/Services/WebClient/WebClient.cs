using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.Services.WebClient
{
    public class WebClient : IWebClient
    {
        private readonly HttpClient client;

        public WebClient(HttpClient client)
        {
            this.client = client;
        }

        public Task GetJsonResponse(string endpoint)
        {
            throw new NotImplementedException();
        }

        public Task SetupClient(string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);
        }
    }
}
