using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace DependencyInjection
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Version 1
            //using IHost host = Host.CreateDefaultBuilder()
            //    .ConfigureServices(ConfigureServices)
            //    .Build();

            //UsingAContainer(host.Services);

            // version 2
            await Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                    config.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args))
                .ConfigureLogging(logging =>
                {
                    // logging.AddConsole().AddFilter(level => level >= LogLevel.Error);
                })
                .ConfigureServices(services =>
                {
                    services.AddHostedService<GreetingHost>();
                    services.AddTransient<IGreetingService, GreetingService>();
                    services.AddTransient<HelloController>();
                }).RunConsoleAsync(options => options.SuppressStatusMessages = false);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGreetingService, GreetingService>();
            services.AddTransient<HelloController>();
        }

        private static void UsingAContainer(IServiceProvider container)
        {
            var controller = container.GetService<HelloController>();
            string greeting = controller.Action("Katharina");
            Console.WriteLine(greeting);
        }
    }
}
