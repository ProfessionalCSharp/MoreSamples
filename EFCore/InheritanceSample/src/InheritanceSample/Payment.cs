namespace InheritanceSample
{
    public abstract class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
    }
}
