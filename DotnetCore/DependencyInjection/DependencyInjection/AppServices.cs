using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public class AppServices
    {
        private AppServices()
        {
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

        public IServiceProvider Container { get; }

        public IServiceProvider GetServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddTransient<HelloController>();
            return services.BuildServiceProvider();
        }
    }
}
