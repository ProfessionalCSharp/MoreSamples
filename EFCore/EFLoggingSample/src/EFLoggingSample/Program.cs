using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EFLoggingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILoggerFactory loggerFactory = EnableLogging();
            RegisterServices(loggerFactory);
            CreateDatabase();
        }

        private static ILoggerFactory EnableLogging()
        {
            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole(LogLevel.Information);

            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Log started");

            return loggerFactory;
        }

        private static void CreateDatabase()
        {
            using (var context = Container.GetService<BooksContext>())
            {
                context.Database.EnsureCreated();
                context.Books.Add(new Book { Title = "Professional C# 6 and .NET Core 1.0", Publisher = "Wrox Press" });
                context.SaveChanges();
            }
        }

        private static void RegisterServices(ILoggerFactory loggerFactory)
        {
            var services = new ServiceCollection();
            services.AddDbContext<BooksContext>(options =>
            {
                options.UseSqlServer(@"server=(localdb)\MSSqlLocalDb;Database=LoggingSample;trusted_connection=true");
                options.UseLoggerFactory(loggerFactory);
                options.EnableSensitiveDataLogging();
            });

            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
