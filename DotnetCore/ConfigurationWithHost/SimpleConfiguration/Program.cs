using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SimpleConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = SetupSimpleConfiguration();
            ReadSimpleConfiguration(configuration);

            configuration = SetupConfigurationWithMultipleProviders(args);
        }

        private static void ReadSimpleConfiguration(IConfiguration configuration)
        {
            Console.WriteLine(nameof(ReadSimpleConfiguration));
            string val1 = configuration["SimpleConfig"];
            Console.WriteLine($"Read {val1} using the key SimpleConfig");
            Console.WriteLine();
        }

        private static IConfiguration SetupSimpleConfiguration()
          => new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

        private static IConfiguration SetupConfigurationWithMultipleProviders(string[] args) =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

        private static IConfiguration SetupConfigurationWithOptionalSettings()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_Environment") ?? "Production";

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();
        }

        private static void ReadConfigurationWithOptionalSettings(IConfiguration configuration)
        {
            Console.WriteLine(nameof(ReadConfigurationWithOptionalSettings));
            Console.WriteLine(configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
            Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));
            Console.WriteLine();
        }
    }
}
