using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFReadonlyProperties
{
    public class Book
    {
        private string _internalState = string.Empty;
        public Book(string title, string publisher, string author)
        {
            Title = title;
            _publisher = publisher;
            Author = author;
            _internalState = "initialized";
        }
        // field only
        private int _bookId = 0;

        // read-write property
        public string Title { get; set; }

        // read-only property with a field mapping
        private string _publisher;
        public string Publisher => _publisher;

        // private accessor with a property
        public string Author { get; private set; }

        public override string ToString() =>
            $"{Title}, {Publisher}, {Author}, id: {_bookId}, internal state: {_internalState}";
    }
}
