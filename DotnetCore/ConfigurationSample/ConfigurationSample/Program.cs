using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConfigurationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = SetupSimpleConfiguration();
            ReadSimpleConfiguration(config);

            config = SetupConfigurationWithMultipleProviders(args);
            ReadConfigurationWithMultipleProviders(config);

            config = SetupConfigurationWithOptionalSettings();
            ReadConfigurationWithOptionalSettings(config);

            using var host = SetupConfigurationWithHost();
            ReadConfigurationUsingHost(host);
        }

        private static IHost SetupConfigurationWithHost() 
            => Host.CreateDefaultBuilder().Build();

        private static void ReadConfigurationUsingHost(IHost host)
        {
            Console.WriteLine(nameof(ReadConfigurationUsingHost));
            var configuration = host.Services.GetService<IConfiguration>();
            Console.WriteLine($"connection string: {configuration.GetSection("ConnectionStrings")["DefaultConnection"]}");
            Console.WriteLine($"connection string: {configuration.GetConnectionString("DefaultConnection")}");
            Console.WriteLine();
        }

        private static void ReadConfigurationWithMultipleProviders(IConfiguration configuration)
        {
            Console.WriteLine(nameof(ReadConfigurationWithMultipleProviders));
            string val1 = configuration["SimpleConfig"] ?? "no value";
            string val2 = configuration["config1"] ?? "no value";
            string val3 = configuration["config2"] ?? "no value";
            Console.WriteLine($"three config values: {val1} {val2} {val3}");
            Console.WriteLine();
        }

        private static void ReadSimpleConfiguration(IConfiguration configuration)
        {
            Console.WriteLine(nameof(ReadSimpleConfiguration));
            string val1 = configuration?["SimpleConfig"] ?? "no value";
            Console.WriteLine($"Read {val1} using the key SimpleConfig");
            Console.WriteLine();
        }

        private static IConfiguration SetupSimpleConfiguration() 
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        private static IConfiguration SetupConfigurationWithMultipleProviders(string[] args) 
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();

        private static IConfiguration SetupConfigurationWithOptionalSettings()
        {
            string? environment = Environment.GetEnvironmentVariable("DOTNET_Environment");

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();
        }

        private static void ReadConfigurationWithOptionalSettings(IConfiguration configuration)
        {
            Console.WriteLine(nameof(ReadConfigurationWithOptionalSettings));
            Console.WriteLine($"connection string: {configuration.GetSection("ConnectionStrings")["DefaultConnection"]}");
            Console.WriteLine($"connection string: {configuration.GetConnectionString("DefaultConnection")}");
            Console.WriteLine();
        }
    }
}
