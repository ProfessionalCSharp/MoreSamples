using DynamicTabLib.ViewModels;
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

namespace WPFDynamicTabSample.Views
{
    /// <summary>
    /// Interaction logic for TabViewUC.xaml
    /// </summary>
    public partial class TabViewUC : UserControl
    {
        public TabViewUC()
        {
            InitializeComponent();
            ViewModel = (Application.Current as App).Container.GetService<TabViewModel>();
            this.DataContext = this;
        }

        public TabViewModel ViewModel { get; private set; }
    }
}
