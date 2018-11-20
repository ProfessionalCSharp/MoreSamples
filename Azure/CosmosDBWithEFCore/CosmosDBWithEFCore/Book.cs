using System;

namespace CosmosDBWithEFCore
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
    }
}
