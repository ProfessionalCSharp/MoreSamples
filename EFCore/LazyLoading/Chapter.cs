namespace LazyLoading
{
    public class Chapter
    {
        public Chapter(int chapterId, int number, string title) => 
            (ChapterId, Number, Title) = (chapterId, number, title);

        public int ChapterId { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
