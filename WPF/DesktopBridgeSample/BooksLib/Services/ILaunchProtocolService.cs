using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public interface ILaunchProtocolService
    {
        Task LaunchAppAsync(string protocol);
    }
}
