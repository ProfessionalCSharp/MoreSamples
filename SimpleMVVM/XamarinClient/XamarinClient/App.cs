using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Services;
using SharedLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinClient.LocalServices;

namespace XamarinClient
{
	public class App : Application
	{
		public App ()
		{
            RegisterServices();
            // The root page of your application
            //MainPage = new ContentPage {
            //	Content = new StackLayout {
            //		VerticalOptions = LayoutOptions.Center,
            //		Children = {
            //			new Label {
            //				XAlign = TextAlignment.Center,
            //				Text = "Welcome to Xamarin Forms!"
            //			}
            //		}
            //	}
            //};
            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<MainViewModel>();
            services.AddSingleton<IMessageService, XamarinMessageService>();
            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }
	}
}
