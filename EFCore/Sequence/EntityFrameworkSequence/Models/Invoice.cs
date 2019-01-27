using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSequence.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]       
        public long InvoiceNumber { get; set; }
        public string Text { get; set; }
    }
}
