namespace NullableReferenceTypesSamples
{
    class Book
    {
        public string Title { get; }
        public string Publisher { get; }
        public string? Isbn { get; }
        public Book(string title, string publisher, string? isbn)
            => (Title, Publisher, Isbn) = (title, publisher, isbn);

        public Book(string title, string publisher)
            : this(title, publisher, null) { }

        public void Deconstruct(out string title, out string publisher, out string? isbn)
            => (title, publisher, isbn) = (Title, Publisher, Isbn);

        public override string ToString() => Title;
    }
}
