using ClientLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using ClientLib.Events;

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
