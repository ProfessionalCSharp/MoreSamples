using BooksLib.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public class BooksService : BindableBase, IBooksService
    {     
        private ObservableCollection<Book> _books = new ObservableCollection<Book>();
        private readonly IBooksRepository _booksRepository;

        public event EventHandler<Book> SelectedBookChanged;

        public BooksService(IBooksRepository repository)
        {
            _booksRepository = repository;
            Task t = RefreshAsync();
        }

        public ObservableCollection<Book> Books => _books;

        private Book _selectedItem;
        public Book SelectedBook
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value))
                {
                    SelectedBookChanged?.Invoke(this, _selectedItem);
                }
            }
        }

        public async Task<Book> AddOrUpdateAsync(Book book)
        {
            Book updated = null;
            if (book.BookId == 0)
            {
                updated = await _booksRepository.AddBookAsync(book);
            }
            else
            {
                updated = await _booksRepository.UpdateBookAsync(book);
            }
            return updated;
        }

        public Task DeleteAsync(Book book) =>
            _booksRepository.DeleteBookAsync(book.BookId);

        public async Task RefreshAsync()
        {
            IEnumerable<Book> books = await _booksRepository.GetBooksAsync();
            _books.Clear();
            foreach (var book in books)
            {
                _books.Add(book);
            }
            SelectedBook = Books.FirstOrDefault();
        }
    }
}
