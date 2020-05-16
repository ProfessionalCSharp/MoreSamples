using Books.Shared;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Books.API.Services
{
    public class BooksService
    {
        private readonly ILogger _logger;

        public BooksService(ILogger<BooksService> logger)
            => _logger = logger;

        private List<Book> _books = new List<Book>()
        {
            new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 3", Publisher = "Wrox Press"},
            new Book { BookId = 2, Title = "Professional C# 9 and .NET 5", Publisher = "Wrox Press"}
        };

        public IEnumerable<Book> GetBooks()
        {
            _logger.LogTrace("GetBooks invoked");
            return _books;
        }
    }
}
