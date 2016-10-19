using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetupSimpleConfiguration();
            ReadSimpleConfiguration();

            SetupConfigurationWithMultipleProviders(args);
            ReadConfigurationWithMultipleProviders();

            SetupConfigurationWithOptionalSettings();
            ReadConfigurationWithOptionalSettings();
        }

        private static void ReadConfigurationWithMultipleProviders()
        {
            Console.WriteLine(nameof(ReadConfigurationWithMultipleProviders));
            string val1 = Config["SimpleConfig"];
            string val2 = Config["config1"];
            string val3 = Config["config2"];
            Console.WriteLine($"{val1} {val2} {val3}");
            Console.WriteLine();
        }

        private static void ReadSimpleConfiguration()
        {
            Console.WriteLine(nameof(ReadSimpleConfiguration));
            string val1 = Config["SimpleConfig"];
            Console.WriteLine($"Read {val1} using the key SimpleConfig");
            Console.WriteLine();
        }

        private static void SetupSimpleConfiguration()
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();  
        }

        private static void SetupConfigurationWithMultipleProviders(string[] args)
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();
        }

        public static IConfigurationRoot Config { get; private set; }

        private static void SetupConfigurationWithOptionalSettings()
        {
            string environment = Environment.GetEnvironmentVariable("Environment");

            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();
        }

        private static void ReadConfigurationWithOptionalSettings()
        {
            Console.WriteLine(nameof(ReadConfigurationWithOptionalSettings));
            Console.WriteLine(Config.GetSection("ConnectionStrings")["DefaultConnection"]);
            Console.WriteLine(Config.GetConnectionString("DefaultConnection"));
            Console.WriteLine();
        }        
    }
}
