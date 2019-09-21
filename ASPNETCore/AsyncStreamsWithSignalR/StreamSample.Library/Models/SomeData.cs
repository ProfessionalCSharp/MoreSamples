namespace StreamSample.Models
{
    public struct SomeData
    {
        public int Value { get; set; }

        public override string ToString() => Value.ToString();
    }
}
