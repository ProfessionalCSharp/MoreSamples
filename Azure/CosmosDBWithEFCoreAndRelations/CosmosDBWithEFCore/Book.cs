using Microsoft.EntityFrameworkCore;
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

        public Book()
        {

        }

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

        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        //private readonly List<Chapter> _chapters = new List<Chapter>();
        //public ICollection<Chapter> Chapters => _chapters;
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();

        //private readonly List<Author> _authors = new List<Author>();
        //public ICollection<Author> Authors => _authors;
       
        public Author LeadAuthor { get; set; } = new Author();
    }
}
