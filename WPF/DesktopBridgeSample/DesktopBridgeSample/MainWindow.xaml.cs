using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DesktopBridgeSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public BooksViewModel ViewModel { get; }  = AppServices.Instance.ServiceProvider.GetService<BooksViewModel>();
    }
}
