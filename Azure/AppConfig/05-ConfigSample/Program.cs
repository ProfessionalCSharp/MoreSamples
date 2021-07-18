using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core.Diagnostics;
using Azure.Identity;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConfigSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var listener = AzureEventSourceListener.CreateConsoleLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var settings = config.Build();

                    config.AddAzureAppConfiguration(options =>
                    {
                        DefaultAzureCredentialOptions credOptions = new() { ExcludeInteractiveBrowserCredential = false };
                        credOptions.Diagnostics.IsLoggingContentEnabled = true;
                        DefaultAzureCredential credential = new(credOptions);
                        var endpoint = settings["AzureAppConfigurationEndpoint"];
                        options.Connect(new Uri(endpoint), credential)
                            .Select("AppConfigurationSample:*", labelFilter: LabelFilter.Null)
                            .Select("AppConfigurationSample:*", context.HostingEnvironment.EnvironmentName)
                            .ConfigureRefresh(refreshConfig =>
                            {
                                refreshConfig.Register("sentinel", refreshAll: true);
                            });

                        var r = options.GetRefresher();
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
