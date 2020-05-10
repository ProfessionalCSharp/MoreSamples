using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IGreetingService, GreetingService>();
                    services.AddTransient<HelloController>();
                })
                .Build();
            var controller = host.Services.GetService<HelloController>();
            string result = controller.Action("Stephanie");
            Console.WriteLine(result);
        }
    }
}
