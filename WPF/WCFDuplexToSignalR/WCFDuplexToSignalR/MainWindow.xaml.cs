using ClientLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WCFDuplexToSignalR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = (Application.Current as App).Container.GetService<MainPageViewModel>();
            this.DataContext = this;

           

            //var eventAggregator = (Application.Current as App).Container.GetService<IEventAggregator>();

            //eventAggregator.GetEvent<MessageEvent>().Subscribe(
            //    s =>
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            ViewModel.Messages.Add(s);
            //        });
            //    });

        }

        public MainPageViewModel ViewModel { get; private set; }
    }
}
