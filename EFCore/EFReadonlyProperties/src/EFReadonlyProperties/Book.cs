namespace EFReadonlyProperties
{
    public class Book
    {
        private Book()
        {

        }
        public Book(string title, string publisher)
        {
            Title = title;
            _publisher = publisher;
        }
        private int _bookId = 0;
        public int BookId => _bookId;

        public string Title { get; set; }

        private string _publisher;
        public string Publisher => _publisher;
    }
}
