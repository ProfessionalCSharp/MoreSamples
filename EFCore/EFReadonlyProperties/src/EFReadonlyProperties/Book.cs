namespace EFReadonlyProperties
{
    public class Book
    {
        private Book()
        {

        }

        private string _internalState = string.Empty;
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

        public override string ToString() =>
            $"{Title}, {Publisher}, internal state: {_internalState}";

    }
}
