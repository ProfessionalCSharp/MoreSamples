using SelectExpressionWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SelectExpressionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IList<Book> _books;
        public MainWindow()
        {
            InitializeComponent();
            _books = new ObservableCollection<Book>(new BookFactory().GetBooks());
            this.DataContext = _books;
        }

        private void OnShowBook(object sender, RoutedEventArgs e)
        {

        }

        private void OnChangeBook(object sender, RoutedEventArgs e)
        {

        }

        private void OnAddBook(object sender, RoutedEventArgs e)
        {

        }
    }
}
