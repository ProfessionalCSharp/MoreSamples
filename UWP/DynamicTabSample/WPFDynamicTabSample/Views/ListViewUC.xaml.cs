using DynamicTabLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace WPFDynamicTabSample.Views
{
    /// <summary>
    /// Interaction logic for ListViewUC.xaml
    /// </summary>
    public partial class ListViewUC : UserControl
    {
        public ListViewUC()
        {
            InitializeComponent();
            ViewModel = (Application.Current as App).Container.GetService<ListViewModel>();
            this.DataContext = this;
        }

        public ListViewModel ViewModel { get; private set; }
    }
}
