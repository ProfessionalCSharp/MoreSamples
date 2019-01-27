using System.Collections.Generic;

#nullable enable

namespace LazyLoading
{
    public class Book
    {
        public Book(int bookId, string title) => (BookId, Title) = (bookId, title);

        public Book(int bookId, string title, string publisher) => (BookId, Title, Publisher) = (bookId, title, publisher);

        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Publisher { get; set; }
        public virtual ICollection<Chapter> Chapters { get; } = new List<Chapter>();
        public int? AuthorId { get; set; }
        public int? ReviewerId { get; set; }
        public int? EditorId { get; set; }

        public virtual User? Author { get; set; }
        public virtual User? Reviewer { get; set; }
        public virtual User? Editor { get; set; }
    }
}
