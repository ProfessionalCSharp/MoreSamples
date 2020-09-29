using System;

namespace CosmosDBWithEFCore
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
    }
}
