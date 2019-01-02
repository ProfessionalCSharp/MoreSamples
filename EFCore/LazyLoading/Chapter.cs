namespace LazyLoading
{
    public class Chapter
    {
        public Chapter(int number, string title)
        {
            Number = number;
            Title = title;
        }

        public int ChapterId { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
