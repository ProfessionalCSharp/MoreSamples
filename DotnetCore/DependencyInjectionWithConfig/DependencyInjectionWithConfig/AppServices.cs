using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DependencyInjectionWithConfig
{
    public class AppServices
    {
        private AppServices()
        {
            Configuration = GetConfiguration();
            Container = GetServices();
        }

        private static AppServices? _instance;
        public static AppServices Instance => GetAppServices();

        private static object _sync = new object();
        private static AppServices GetAppServices()
        {
            lock (_sync)
            {
                if (_instance == null)
                {
                    _instance = new AppServices();
                }
                return _instance;
            }
        }

        public IConfiguration Configuration { get; }

        public IConfiguration GetConfiguration() 
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public IServiceProvider Container { get; }

        public IServiceProvider GetServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<HelloController>();
            services.AddOptions();
            services.AddGreetingService(Configuration.GetSection("GreetingService"));
            return services.BuildServiceProvider();
        }
    }
}
