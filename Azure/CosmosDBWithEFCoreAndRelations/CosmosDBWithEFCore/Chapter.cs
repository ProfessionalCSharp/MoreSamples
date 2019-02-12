using System;

namespace CosmosDBWithEFCore
{
    public class Chapter
    {
        // does it work with read-only properties?
        public Chapter(int number, string title, int pages)
            => (Number, Title, Pages) = (number, title, pages);

        public Guid ChapterId { get; } = Guid.NewGuid();
        public int Number { get; }
        public string Title { get; }
        public int Pages { get; }

        //public static Chapter Create(int number, string title, int pages) =>
        //    new Chapter
        //    {
        //        ChapterId = Guid.NewGuid(),
        //        Number = number,
        //        Title = title,
        //        Pages = pages
        //    };

        //public Guid ChapterId { get; set; }
        //public int Number { get; set; }
        //public string Title { get; set; }
        //public int Pages { get; set; }
    }
}
