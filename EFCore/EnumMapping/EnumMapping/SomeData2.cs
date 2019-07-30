using System.Collections.Generic;

namespace EnumMapping
{
    public class SomeData2
    {
        public int SomeData2Id { get; set; }
        public string? Text { get; set; }
        public LookupValue? LookupValue { get; set; }
    }

    public class LookupValue
    {
        public int LookupValueId { get; set; }
        public CustomValues CustomValue { get; set; }
        public ICollection<SomeData2> SomeData2 { get; set; } = default!;
    }
}
