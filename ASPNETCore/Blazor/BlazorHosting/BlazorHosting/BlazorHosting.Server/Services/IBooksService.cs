using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorHosting.Shared;

namespace BlazorHosting.Server.Services
{
    public interface IBooksService
    {
        Book AddBook(Book book);
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        void UpdateBook(Book book);
    }
}