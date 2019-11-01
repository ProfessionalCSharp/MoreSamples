using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DependencyInjectionWithConfig
{
    public class Program
    {
        public static void Main()
        {
            UseServicesWithConfig();
            UseServicesWithHost();
        }

        private static void UseServicesWithHost()
        {
            using var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddGreetingService(context.Configuration.GetSection("GreetingService"));
                    services.AddSingleton<IGreetingService, GreetingService>();
                    services.AddTransient<HelloController>();
                }).Build();

            var controller = host.Services.GetService<HelloController>();
            string greeting = controller.Action("Katharina");
            Console.WriteLine(greeting);
        }

        private static void UseServicesWithConfig()
        {
            var controller = AppServices.Instance.Container.GetService<HelloController>();

            string greeting = controller.Action("Katharina");

            Console.WriteLine(greeting);
        }
    }
}