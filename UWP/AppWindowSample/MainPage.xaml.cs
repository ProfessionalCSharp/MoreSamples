using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppWindowSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private AppWindow _appWindow;
        private readonly Frame _frame = new Frame();
        public MainPage()
        {
            ThreadId = Thread.CurrentThread.ManagedThreadId;
            this.InitializeComponent();
        }

        public int ThreadId { get; set; }

        private async void OnAppWindow(object sender, RoutedEventArgs e)
        {
            _appWindow = await AppWindow.TryCreateAsync();
            _appWindow.Closed += (s, args) =>
            {
                _appWindow = null;
                _frame.Content = null;
            };
            _frame.Navigate(typeof(SecondPage));
            ElementCompositionPreview.SetAppWindowContent(_appWindow, _frame);
            await _appWindow.TryShowAsync();
        }

        private async void OnAppView(object sender, RoutedEventArgs e)
        {
            CoreApplicationView view = CoreApplication.CreateNewView();
            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var frame = new Frame();
                frame.Navigate(typeof(SecondPage));
                Window.Current.Content = frame;
                Window.Current.Activate();
                int id = ApplicationView.GetForCurrentView().Id;
                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(id);
            });



        }
    }
}
