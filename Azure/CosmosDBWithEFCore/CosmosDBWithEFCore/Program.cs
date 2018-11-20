using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CosmosDBWithEFCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConfigureServices();
            var service = Container.GetRequiredService<BooksService>();
            await service.CreateTheDatabaseAsync();
            await service.WriteBooksAsync();
            service.ReadBooks();
            Console.WriteLine("completed");
        }

        public static void ConfigureServices()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

#if DEBUG
            configurationBuilder.AddUserSecrets("1E2D66CC-11C9-4DE7-B25E-F1EAA5F0154A");
#endif
            IConfigurationRoot config = configurationBuilder.Build();

            IConfigurationSection configSection = config.GetSection("CosmosSettings");

            var services = new ServiceCollection();
            services.AddDbContext<BooksContext>(options => options.UseCosmos(configSection["ServiceEndpoint"], configSection["AuthKey"], configSection["DatabaseName"]));
            services.AddTransient<BooksService>();

            services.AddLogging(options =>
                options.AddDebug().SetMinimumLevel(LogLevel.Trace));

            Container = services.BuildServiceProvider();
        }

        public static ServiceProvider Container { get; private set; }
    }
}
