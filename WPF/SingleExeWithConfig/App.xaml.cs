using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using SingleExeWithConfig.ViewModels;

namespace SingleExeWithConfig
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider AppServices { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var host = Host.CreateDefaultBuilder().ConfigureHostConfiguration(config =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            }).ConfigureServices(services =>
            {
                services.AddTransient<MainWindowViewModel>();
            }).Build();

            AppServices = host.Services;
        }
    }
}
