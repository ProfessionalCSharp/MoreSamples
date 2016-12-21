using DynamicTabLib.Framework;
using DynamicTabLib.Services;
using DynamicTabLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFDynamicTabSample.Services;

namespace WPFDynamicTabSample
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
            services.AddSingleton<IItemsService, ItemsService>();
            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddSingleton<IOpenItemsDetailService, OpenItemsDetailService>();
            services.AddSingleton<IItemDetailViewModelFactory, ItemDetailViewModelFactory>();
            services.AddTransient<ListViewModel>();
            services.AddTransient<TabViewModel>();
            services.AddTransient<ItemDetailViewModel>();
            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }
    }
}
