using System.Collections.Generic;
using WebFormsWithDI.Models;

namespace WebFormsWithDI.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks();
    }
}