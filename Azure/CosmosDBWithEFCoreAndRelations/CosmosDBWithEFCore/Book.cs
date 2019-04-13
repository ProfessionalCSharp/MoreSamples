using System;
using System.Collections.Generic;

namespace CosmosDBWithEFCore
{
    public class Book
    {
        public Book(string title, string publisher)
            : this(title, publisher, Author.Empty)
        { }

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
        public string? Publisher { get; set; }

        public List<Chapter> Chapters { get; set; }
       
        public Author LeadAuthor { get; set; }
    }
}
