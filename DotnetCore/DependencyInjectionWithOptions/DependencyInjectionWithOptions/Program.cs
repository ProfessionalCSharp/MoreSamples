using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DependencyInjectionWithOptions
{
    public class Program
    {
        public static void Main()
        {
            UseServices();
            UsingHost();
        }

        private static void UseServices()
        {
            var controller = AppServices.Instance.Container.GetService<HelloController>();

            string greeting = controller.Action("Stephanie");

            Console.WriteLine(greeting);
        }

        private static void UsingHost()
        {
            using var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddGreetingService(options =>
                    {
                        options.From = "Angela";
                    });
                    services.AddSingleton<IGreetingService, GreetingService>();
                    services.AddTransient<HelloController>();
                }).Build();

            var controller = host.Services.GetService<HelloController>();
            string greeting = controller.Action("Katharina");
            Console.WriteLine(greeting);
        }
    }
}
