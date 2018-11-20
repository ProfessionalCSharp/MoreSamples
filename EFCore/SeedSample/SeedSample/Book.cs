using System.Collections.Generic;

namespace SeedSample
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public override string ToString() => $"id: {BookId}, title: {Title}, publisher: {Publisher}";
    }
}
