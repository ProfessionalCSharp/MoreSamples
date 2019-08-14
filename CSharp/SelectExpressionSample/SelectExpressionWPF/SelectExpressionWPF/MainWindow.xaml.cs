using SelectExpressionWPF.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

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
