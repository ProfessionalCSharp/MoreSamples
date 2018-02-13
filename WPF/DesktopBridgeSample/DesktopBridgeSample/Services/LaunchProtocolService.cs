using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace DesktopBridgeSample.Services
{
    public class LaunchProtocolService : ILaunchProtocolService
    {
        public async Task LaunchAppAsync(string protocol)
        {
            await Launcher.LaunchUriAsync(new Uri($"{protocol}://"));
        }
    }
}
