using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BooksLib.Models;

namespace BooksLib.Services
{
    public interface IBooksService
    {
        ObservableCollection<Book> Books { get; }
        Book SelectedBook { get; set; }

        event EventHandler<Book> SelectedBookChanged;

        Task<Book> AddOrUpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task RefreshAsync();
    }
}