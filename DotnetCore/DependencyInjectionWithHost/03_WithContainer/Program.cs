using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main()
        {
            using var container = GetContainer();
            var controller = container.GetService<HelloController>();
            string result = controller.Action("Katharina");
            Console.WriteLine(result);
        }

        static ServiceProvider GetContainer()
        {
            var services = new ServiceCollection();
            services.AddTransient<IGreetingService, GreetingService>();
            services.AddTransient<HelloController>();
            return services.BuildServiceProvider();
        }
    }
}
