using ComponentsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComponentsLibrary.Models;

namespace ViewComponentsSample.Services
{
    public class BooksSampleService : IBooksService
    {
        private List<Book> _books = new List<Book>
        {
            new Book(1, "Professional C# 6 and .NET Core 1.0", "Wrox Press"),
            new Book(2, "Professional C# 5.0 and .NET 4.5.1", "Wrox Press"),
            new Book(3, "Enterprise Services with the .NET Framework", "Addison Wesley")
        };

        public Task<IEnumerable<Book>> GetBooksAsync() => 
            Task.FromResult<IEnumerable<Book>>(_books);
    }
}
