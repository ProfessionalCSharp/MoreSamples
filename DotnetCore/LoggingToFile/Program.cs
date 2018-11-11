using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace LoggingConfigurationSample
{
    class Program
    {
        private static string s_url = "https://csharp.christiannagel.com";

        static async Task Main(string[] args)
        {
            if (args.Length == 1)
            {
                s_url = args[0];
            }


            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            RegisterServices(configuration);
            await RunSampleAsync();

            // flush and close listeners and logs
            s_listener.Flush();
            s_listener.Dispose();
            Log.CloseAndFlush();

            AppServices.Dispose();

            Console.ReadLine();
        }

        static async Task RunSampleAsync()
        {
            var controller = AppServices.GetService<SampleController>();
            await controller.NetworkRequestSampleAsync(s_url);
        }

        //static void ConfigureSeriLogging()
        //{
        //    Log.Logger = new LoggerConfiguration()
        //        .WriteTo.File("serilog.txt").CreateLogger();
        //}

        private static TraceListener s_listener;
        static void ConfigureTraceSourceLogging()
        {
            var writer = File.CreateText("logfile.txt");

            s_listener = new TextWriterTraceListener(writer.BaseStream);
        }

        static void RegisterServices(IConfiguration configuration)
        {
            // ConfigureSeriLogging();  // static configuration instead of passing a logger to AddSerilog
            ConfigureTraceSourceLogging();

            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.AddConfiguration(configuration.GetSection("Logging"))
                    .AddTraceSource(new SourceSwitch("TraceSourceLog", SourceLevels.Verbose.ToString()), s_listener)
                    .AddSerilog(new LoggerConfiguration().WriteTo.File("serilog.txt").CreateLogger())
                    .AddConsole();
#if DEBUG
                builder.AddDebug();
#endif
            });
            services.AddHttpClient<SampleController>();
            AppServices = services.BuildServiceProvider();
        }

        public static ServiceProvider AppServices { get; private set; }
    }
}
