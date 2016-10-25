using Microsoft.EntityFrameworkCore;

namespace InheritanceSample
{
    public class PaymentsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocaldb;database=PaymentsSample1;trusted_connection=true");
        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CashPayment> CashPayments { get; set; }
        public DbSet<CreditcardPayment> CreditcardPayments { get; set; }
    }

    public class Payments2Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocaldb;database=PaymentsSample2;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasDiscriminator<string>("type")
                .HasValue<CashPayment>("cash")
                .HasValue<CreditcardPayment>("creditcard");
        }
        public DbSet<Payment> Payments { get; set; }
    }
}
