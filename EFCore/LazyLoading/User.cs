using System.Collections.Generic;

namespace LazyLoading
{
    public class User
    {
        public User(string name) => Name = name;

        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual List<Book> WrittenBooks { get; set; } = new List<Book>();
        public virtual List<Book> ReviewedBooks { get; set; } = new List<Book>();
        public virtual List<Book> EditedBooks { get; set; } = new List<Book>();
    }
}
