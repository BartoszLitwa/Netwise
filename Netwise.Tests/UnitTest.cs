using Netwise.Infrastructure.Services.WebClient;
using System;
using System.Net.Http;
using Xunit;

namespace Netwise.Tests
{
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            var webClient = SetupWebClient();
        }

        private WebClient SetupWebClient()
        {
            var webClient = new WebClient(new HttpClient());

            webClient.SetupClient("https://catfact.ninja");

            return webClient;
        }
    }
}
