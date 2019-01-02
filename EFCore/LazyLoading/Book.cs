using System.Collections.Generic;

namespace LazyLoading
{
    public class Book
    {
        public Book(string title)
        {
            Title = title;
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Chapter> Chapters { get; } = new List<Chapter>();

        public virtual User? Author { get; set; }
        public virtual User? Reviewer { get; set; }
        public virtual User? Editor { get; set; }
    }
}
