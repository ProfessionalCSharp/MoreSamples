using System;

namespace CosmosDBWithEFCore
{
    public class Chapter
    {
        public static Chapter Create(int number, string title, int pages) =>
            new Chapter
            {
                ChapterId = Guid.NewGuid(),
                Number = number,
                Title = title,
                Pages = pages
            };

        public Guid ChapterId { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public Book Book { get; set; }
    }
}
