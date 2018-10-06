using BooksLib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public interface  IBooksRepository 
    {
        Task<Book> GetBookAsync(int id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> AddBookAsync(Book item);
        Task<Book> UpdateBookAsync(Book item);
        Task<bool> DeleteBookAsync(int id);
    }
}
