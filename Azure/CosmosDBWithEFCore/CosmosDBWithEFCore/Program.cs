using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CosmosDBWithEFCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                using var host = Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration(config =>
                    {
                        config.AddUserSecrets("1E2D66CC-11C9-4DE7-B25E-F1EAA5F0154A");
                    }).ConfigureServices((context, services) =>
                    {
                        IConfigurationSection configSection = context.Configuration.GetSection("CosmosSettings");

                        services.AddDbContext<BooksContext>(options => options.UseCosmos(configSection["ServiceEndpoint"], configSection["AuthKey"], configSection["DatabaseName"]));
                        services.AddTransient<BooksService>();
                    }).Build();

                var service = host.Services.GetRequiredService<BooksService>();
                await service.CreateTheDatabaseAsync();
                await service.WriteBooksAsync();
                service.ReadBooks();
                Console.WriteLine("completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
