using System.Collections.Generic;

namespace LazyLoading
{
    public class User
    {
        public User(int userId, string name) => (UserId, Name) = (userId, name);

        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual List<Book> WrittenBooks { get; } = new List<Book>();
        public virtual List<Book> ReviewedBooks { get; } = new List<Book>();
        public virtual List<Book> EditedBooks { get; } = new List<Book>();
    }
}
