using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.Services.FileHandler
{
    public class FileHandler : IFileHandler
    {
        private string path;

        public FileHandler()
        {

        }

        public void CreateNewFile()
        {
            using var file = File.Create(path);
        }

        public void SetupClient(string path)
        {
            this.path = path;
            // Create new file
            CreateNewFile();
        }

        public async Task AppendToFile(string content)
        {
            using var file = new StreamWriter(path, append: true);
            await file.WriteLineAsync(content);
        }

        public async Task WriteToFile(string content)
        {
            using var file = new StreamWriter(path, append: false);
            await file.WriteLineAsync(content);
        }

        public async Task<string[]> ReadAllFromFile()
        {
            return await File.ReadAllLinesAsync(path);
        }
    }
}
