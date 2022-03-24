using Netwise.Domain.Domain;
using Netwise.Infrastructure.Services.FileHandler;
using Netwise.Infrastructure.Services.WebClient;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Netwise.Tests
{
    public class UnitTest
    {
        [Fact]
        public async Task ReturnsJsonResponse_WebClient()
        {
            var webClient = SetupWebClient();

            var resp = await webClient.GetJsonResponse<FactResponse>("/fact");
            
            Assert.NotNull(resp);
        }

        [Fact]
        public async Task AppendsNewLine_WebClient()
        {
            var fileHandler = SetupFileHandler();

            await fileHandler.AppendToFile("testasd fasd fas fasd fasd f");
            await fileHandler.AppendToFile("asdgsdg asdg asd gdas gasg");
            await fileHandler.AppendToFile("asdfasdf asdf asdf");

            var lines = await fileHandler.ReadAllFromFile();

            Assert.NotNull(lines);
            Assert.NotEmpty(lines);
            Assert.Equal("testasd fasd fas fasd fasd f", lines[0]);
            Assert.Equal("asdgsdg asdg asd gdas gasg", lines[1]);
            Assert.Equal("asdfasdf asdf asdf", lines[2]);
        }

        private WebClient SetupWebClient()
        {
            var webClient = new WebClient(new HttpClient());

            webClient.SetupClient("https://catfact.ninja");

            return webClient;
        }

        private FileHandler SetupFileHandler()
        {
            var fileHandler = new FileHandler();

            fileHandler.SetupClient("test.txt");

            return fileHandler;
        }
    }
}
