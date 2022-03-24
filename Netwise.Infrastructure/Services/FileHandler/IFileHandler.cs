using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.Services.FileHandler
{
    public interface IFileHandler
    {
        void SetupClient(string path);
        void CreateNewFile();
        Task AppendToFile(string content);
        Task WriteToFile(string content);
        Task<string[]> ReadAllFromFile(); 
    }
}
