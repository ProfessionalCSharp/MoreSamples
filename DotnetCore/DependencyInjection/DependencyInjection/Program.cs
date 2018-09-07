using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Console;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main()
        {
            RegisterServices();

            WithoutUsingAContainer();
            UsingAContainer();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddTransient<HelloController>();
            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }

        private static void WithoutUsingAContainer()
        {
            IGreetingService service = new GreetingService();
            var controller = new HelloController(service);
            string greeting = controller.Action("Matthias");
            WriteLine(greeting);
        }

        private static void UsingAContainer()
        {
            var controller = Container.GetService<HelloController>();
            string greeting = controller.Action("Stephanie");
            WriteLine(greeting);
        }
    }
}
