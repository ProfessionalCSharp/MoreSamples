namespace SelectExpressionWPF.Models
{
    public class Book : BindableBase
    {
        public Book(string title, string publisher)
        {
            _title = title;
            _publisher = publisher;
            
        }
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _publisher;

        public string Publisher
        {
            get => _publisher;
            set => SetProperty(ref _publisher, value);
        }

        public override string ToString() => $"{Title}";
    }
}
