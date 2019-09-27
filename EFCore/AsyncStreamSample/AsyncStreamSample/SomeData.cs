namespace AsyncStreamSample
{
    public class SomeData
    {
        public int SomeDataId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Number { get; set; }

        public override string ToString() => $"id: {SomeDataId}, number: {Number}, text: {Text}";
    }
}
