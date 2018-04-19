using BlazorHosting.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHosting.Server.Services
{
    public class SampleBooksService : IBooksService
    {
        private static readonly List<Book> _books = new List<Book>();

        public SampleBooksService() =>
            _books.AddRange(new[] {
                new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", Publisher = "Wrox Press"},
                new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", Publisher = "Wrox Press"},
                new Book { BookId = 3, Title = "Enterprise Services", Publisher = "Addison Wesley"},
            });

        public Book AddBook(Book book)
        {
            if (book.BookId != -1) throw new InvalidOperationException("invalid book id");

            lock (addBookLock)
            {
                book.BookId = GetNextBookId();
                _books.Add(book);
            }
            return book;
        }

        private object addBookLock = new object();
        public IEnumerable<Book> GetBooks() => _books;
        public Book GetBook(int id) => _books.SingleOrDefault(b => b.BookId == id);
        public void UpdateBook(Book book)
        {
            var existing = _books.Find(b => b.BookId == book.BookId);
            _books.Remove(existing);
            _books.Add(book);
        }

        private int GetNextBookId() => _books.Select(b => b.BookId).Max() + 1;
    }
}
