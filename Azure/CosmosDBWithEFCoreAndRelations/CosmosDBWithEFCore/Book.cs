using System;
using System.Collections.Generic;

namespace CosmosDBWithEFCore
{
    public class Book
    {
        public static Book Create(string title, string publisher, params Chapter[] chapters)
        {
            var book = new Book()
            {
                BookId = Guid.NewGuid(),
                Title = title,
                Publisher = publisher
            };
            book._chapters.AddRange(chapters);
            return book;
        }

        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        private readonly List<Chapter> _chapters = new List<Chapter>();
        public ICollection<Chapter> Chapters => _chapters;
    }
}
