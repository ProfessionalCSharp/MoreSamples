using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsWithDI.Models;

namespace WebFormsWithDI.Services
{
    public class BooksSampleService : IBooksService
    {
        private List<Book> _books = new List<Book>()
        {
            new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", Publisher = "Wrox Press"},
            new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", Publisher = "Wrox Press"},
            new Book { BookId = 3, Title = "Enterprise Services with the .NET Framework", Publisher = "Addison Wesley"},
        };
        public IEnumerable<Book> GetBooks() => _books;

    }
}