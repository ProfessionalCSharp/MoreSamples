using SharedLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace XamarinClient
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            ViewModel = (Application.Current as App).Container.GetService<MainViewModel>();
            this.BindingContext = this;
		}

        public MainViewModel ViewModel { get; }
    }
}
