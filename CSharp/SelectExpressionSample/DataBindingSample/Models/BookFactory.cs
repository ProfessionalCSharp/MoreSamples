using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingSample.Models
{
    public class BookFactory
    {
        public Book GetTheBook() => new Book { Title = "Professional C# 7", Publisher = "Wrox Press" };

        public Book GetBeginingCSharp() => new Book
        {
            Title = "Beginning Visual C#",
            Publisher = "Wrox Press",
            Authors = new[]
        {
            "Karli Watson",
            "Christian Nagel"
        }
        };

        private List<Book> _books = new List<Book>()
        {
            new Book { Title = "Professional C# 7", Publisher = "Wrox Press", Authors = new string[] { "Christian Nagel" } },
            new Book { Title = "Professional C# 6", Publisher = "Wrox Press", Authors = new string[] { "Christian Nagel" } },
            new Book { Title = "Enterprise Services", Publisher = "AWL", Authors = new string[] { "Christian Nagel" } },
        };

        public IEnumerable<Book> GetBooks() => _books;
    }
}
