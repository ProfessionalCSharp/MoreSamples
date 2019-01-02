using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace LazyLoading
{
    public class AppServices
    {
        private const string BooksConnection = nameof(BooksConnection);

        static AppServices()
        {
            Configuration = GetConfiguration();
        }

        private AppServices()
        {
            Container = GetServiceProvider();
        }

        public static AppServices Instance { get; } = new AppServices();

        public IServiceProvider Container { get; }

        public static IConfiguration GetConfiguration() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public static IConfiguration Configuration { get; }

        private ServiceProvider GetServiceProvider() =>
            new ServiceCollection()
                .AddLogging(config =>
                {
                    config
                        .AddConsole()
                        .AddDebug()
                        .AddFilter(level => true);
                })
                .AddTransient<BooksService>()
                .AddDbContext<BooksContext>(options =>
                {
                    options.UseLazyLoadingProxies()
                        .UseSqlServer(Configuration.GetConnectionString(BooksConnection));
                }).BuildServiceProvider();
    }
}
