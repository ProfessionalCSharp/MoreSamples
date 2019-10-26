namespace RangesSample
{
    public class SomeData
    {
        public SomeData(string text)
        {
            Text = text;
        }
        public string Text { get; }
        public override string ToString() => Text;
    }
}
