using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.Services.FileHandler
{
    public interface IFileHandler
    {
        Task CreateNewFile(string name);
        Task WriteToFile(string name);
    }
}
