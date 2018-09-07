using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using static System.Console;

namespace DependencyInjectionWithConfig
{
    public class Program
    {
        public static void Main()
        {
            RegisterServicesWithConfig();
            UseServices();
        }

        private static void RegisterServicesWithConfig()
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot config = configBuilder.Build();

            var services = new ServiceCollection();
            services.AddTransient<HelloController>();
            services.AddOptions();
            services.AddGreetingService(config.GetSection("GreetingService"));

            Container = services.BuildServiceProvider();
        }

        private static void UseServices()
        {
            var controller = Container.GetService<HelloController>();

            string greeting = controller.Action("Katharina");

            WriteLine(greeting);
        }

        public static IServiceProvider Container { get; private set; }
    }
}