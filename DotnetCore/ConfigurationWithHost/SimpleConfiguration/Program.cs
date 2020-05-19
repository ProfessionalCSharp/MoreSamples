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
    }
}
