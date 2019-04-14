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
            _chapters.AddRange(chapters);
        }

        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string? Publisher { get; set; }

        private List<Chapter> _chapters = new List<Chapter>();
        public IEnumerable<Chapter> Chapters => _chapters;
       
        public Author LeadAuthor { get; set; }
    }
}
