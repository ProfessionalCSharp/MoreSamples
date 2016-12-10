using ClientLib.Services;
using ClientLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using SignalRClient;
using System;
using System.Windows;

namespace WCFDuplexToSignalR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegisterServices();
        }

        private void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICommunicationService, SignalRService>();
            services.AddTransient<MainPageViewModel>();
            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }
    }
}
