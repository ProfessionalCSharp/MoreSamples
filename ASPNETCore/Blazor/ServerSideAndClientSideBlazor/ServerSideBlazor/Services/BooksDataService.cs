using BooksLib;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSideBlazor.Services
{
    public class BooksDataService : IBooksService
    {
        private readonly BooksContext _booksContext;
        public BooksDataService(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _booksContext.Books.ToListAsync();
        }
    }
}
