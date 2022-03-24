using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.Services.WebClient
{
    public interface IWebClient
    {
        void SetupClient(string baseAddress);
        Task<T> GetJsonResponse<T>(string endpoint);
    }
}
