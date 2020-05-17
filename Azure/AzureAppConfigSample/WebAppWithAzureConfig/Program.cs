using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace WebAppWithAzureConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)           
                .ConfigureAppConfiguration((context, config) =>
                {
                    var settings = config.Build();
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        var connectionString = settings.GetConnectionString("AzureAppConfiguration");
                        config.AddAzureAppConfiguration(connectionString);                           
                    }
                    else
                    {
                        var credentials = new ManagedIdentityCredential();
                        var endpoint = settings["AppConfigEndpoint"];
                        config.AddAzureAppConfiguration(options =>
                        {
                            options.Connect(new Uri(endpoint), credentials)
                            .ConfigureKeyVault(vault => vault.SetCredential(credentials));
                        });
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
