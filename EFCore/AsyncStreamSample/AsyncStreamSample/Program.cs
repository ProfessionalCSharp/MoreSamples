using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AsyncStreamSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.AddFilter((category, level) =>
                    {
                        return category == DbLoggerCategory.Database.Command.Name
                        && level >= LogLevel.Information;
                    });
                    logging.SetMinimumLevel(LogLevel.Debug);
                    logging.AddDebug();
                    logging.AddConsole();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<SomeDataContext>(options =>
                    {
                        options.UseSqlServer(context.Configuration.GetConnectionString("AsyncStreamsConnection"));
                    });
                    services.AddTransient<IStreamingService, StreamingService>();
                }).Build();

            var service = host.Services.GetRequiredService<IStreamingService>();
            await service.CreateTheDatabaseAsync();
            await service.QueryDataAsync();

            
        }
    }
}
