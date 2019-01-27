using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSequence.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public long InvoiceNumber { get; set; }
        public string Text { get; set; }
    }
}
