using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ConfigurationWithHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<Controller>();

                    var configuration = context.Configuration;
                    services.AddControllerWithOptions(configuration.GetSection("MyGroup1"));
                })
                .Build();

            var controller = host.Services.GetRequiredService<Controller>();
            controller.ReadConfigurationValues();
            controller.StronglyTypedConfiguration();

            Console.WriteLine();
            Console.WriteLine("Controller with options...");
            var controllerWithOptions = host.Services.GetRequiredService<ControllerWithOptions>();
            controllerWithOptions.StronglyTypedConfiguration();
        }
    }
}
