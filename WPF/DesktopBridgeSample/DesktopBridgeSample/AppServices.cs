using BooksLib.Services;
using BooksLib.ViewModels;
using DesktopBridgeSample.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using static DesktopBridgeSample.Extensions.FunctionalExtensions;

namespace DesktopBridgeSample
{
    class AppServices
    {
        private AppServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IBooksRepository, BooksSampleRepository>();
            services.AddSingleton<IBooksService, BooksService>();
            services.AddTransient<BooksViewModel>();
            services.AddSingleton<ILaunchProtocolService, LaunchProtocolService>();
            services.AddSingleton<IPackageNameService, PackageNameService>();
            services.AddSingleton<IUpdateTileService, UpdateTileService>();
            services.AddSingleton<IDialogService, WPFDialogService>();
            services.AddSingleton<IAppServiceClientService, AppServiceClientService>();
            services.AddTransient<IRunOnUIThreadService, RunOnUIThreadService>();
            ServiceProvider = services.BuildServiceProvider();
        }

        private static AppServices _instance;

        private static object _instanceLock = new object();

        private static AppServices GetInstance() => Lock(_instanceLock, () => _instance ?? (_instance = new AppServices()));

        public static AppServices Instance => _instance ?? GetInstance();

        public IServiceProvider ServiceProvider { get; }
    }
}
