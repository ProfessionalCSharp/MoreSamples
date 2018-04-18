using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ClientApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }

    }
}
