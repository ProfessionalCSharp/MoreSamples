using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text;

namespace EFCoreSequence.Models
{
    public class SampleContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=InvoiceSampleLegacy;trusted_connection=true";
        public SampleContext()
            : base(ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Invoice>().Property(i => i.InvoiceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .IsRequired();
                
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasSequence<long>(
        //        "InvoiceSequence",
        //        schema: "shared",
        //        options => options.StartsAt(1000).IncrementsBy(3));
        //    modelBuilder.Entity<Invoice>()
        //        .Property(i => i.InvoiceNumber)
        //        .HasDefaultValueSql("NEXT VALUE FOR shared.InvoiceSequence");
        //}

        public DbSet<Invoice> Invoices { get; set; }
    }
}
