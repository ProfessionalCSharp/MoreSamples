using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.EntityFrameworkCore.Design;

namespace EnumMapping
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole().AddFilter(level => true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<SomeDataContext>(options =>
                    {
                        options.UseSqlServer(
                            context.Configuration.GetConnectionString("MappingsConnection"));
                    });
                    services.AddHostedService<Runner>();
                })
                .RunConsoleAsync();
        }

        internal class Runner : BackgroundService
        {
            private readonly SomeDataContext _context;
            public Runner(SomeDataContext context)
            {
                _context = context;
            }

            protected override Task ExecuteAsync(CancellationToken stoppingToken)
            {
                return QuerySampleAsync();
            }

            private async Task QuerySampleAsync()
            {
                var data = await _context.SampleData.ToListAsync();
                foreach (var item in data)
                {
                    Console.WriteLine($"{item.Text} {item.CustomValue}");
                }
            }
        }

        public class SomeDataContextFactory : IDesignTimeDbContextFactory<SomeDataContext>
        {
            private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=MappingsSample;trusted_connection=true";
            public SomeDataContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SomeDataContext>();
                optionsBuilder.UseSqlServer(ConnectionString);

                return new SomeDataContext(optionsBuilder.Options);
            }
        }
    }
}
