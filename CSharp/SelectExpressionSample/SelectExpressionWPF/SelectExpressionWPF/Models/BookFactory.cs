using System.Collections.Generic;

namespace SelectExpressionWPF.Models
{
    public class BookFactory
    {
        private readonly List<Book> _books = new List<Book>()
        {
            new Book("Professional C# 7", "Wrox Press"),
            new Book("Professional C# 6", "Wrox Press"),
            new Book("Enterprise Services", "AWL"),
        };

        public IEnumerable<Book> GetBooks() => _books;
    }
}
