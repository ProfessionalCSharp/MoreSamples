using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main()
        {
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();

            UsingAContainer(host.Services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddTransient<HelloController>();
        }

        private static void UsingAContainer(IServiceProvider container)
        {
            var controller = container.GetService<HelloController>();
            string greeting = controller.Action("Stephanie");
            Console.WriteLine(greeting);
        }
    }
}
