using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AzureAppConfigSample
{
    // https://github.com/Azure/AppConfiguration-DotnetProvider
    class Program
    {
        static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            var config = host.Services.GetService<IConfiguration>();
            string dbConnection = config.GetConnectionString("DbConnection");
            Console.WriteLine(dbConnection);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseEnvironment("Development")
            .ConfigureAppConfiguration((context, config) =>
            {              
                string appConfigurationConnection = Environment.GetEnvironmentVariable("AppConfiguration");
                config.AddAzureAppConfiguration(appConfigurationConnection);
            })
            .ConfigureServices(services =>
            {

            });
    }
}
