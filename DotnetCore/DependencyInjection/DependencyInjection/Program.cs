using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main()
        {
            WithoutUsingAContainer();
            UsingAContainer();
            UsingHost();
        }

        private static void WithoutUsingAContainer()
        {
            IGreetingService service = new GreetingService();
            var controller = new HelloController(service);
            string greeting = controller.Action("Matthias");
            Console.WriteLine(greeting);
        }

        private static void UsingAContainer()
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
                    services.AddSingleton<IGreetingService, GreetingService>();
                    services.AddTransient<HelloController>();
                }).Build();

            var controller = host.Services.GetService<HelloController>();
            string greeting = controller.Action("Katharina");
            Console.WriteLine(greeting);
        }
    }
}
