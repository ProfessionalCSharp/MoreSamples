using System;
using System.Collections.Generic;

namespace CosmosDBWithEFCore
{
    public class Book
    {
        //public static Book Create(string title, string publisher, Author leadAuthor, params Chapter[] chapters)
        //{
        //    var book = new Book()
        //    {
        //        BookId = Guid.NewGuid(),
        //        Title = title,
        //        Publisher = publisher
        //    };
        //    book._chapters.AddRange(chapters);
        //    book._authors.Add(leadAuthor);
        //    return book;
        //}

        public Book(string title, string publisher)
        {
            BookId = Guid.NewGuid();
            Title = title;
            Publisher = publisher;
        }

        public Book(string title, string publisher, Author leadAuthor, params Chapter[] chapters)
        {
            BookId = Guid.NewGuid();
            Title = title;
            Publisher = publisher;
            LeadAuthor = leadAuthor;
            Chapters = new List<Chapter>();
            Chapters.AddRange(chapters);
        }

        public Guid BookId { get; }
        public string Title { get; }
        public string Publisher { get; }

        //private readonly List<Chapter> _chapters = new List<Chapter>();
        //public ICollection<Chapter> Chapters => _chapters;
        public List<Chapter> Chapters { get; set; }

        //private readonly List<Author> _authors = new List<Author>();
        //public ICollection<Author> Authors => _authors;
        public Author LeadAuthor { get; set; }
    }
}
