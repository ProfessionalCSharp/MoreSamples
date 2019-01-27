using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSequence.Models
{
    public class SampleContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=InvoiceSample2;trusted_connection=true";
        public SampleContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<long>(
                "InvoiceSequence",
                schema: "shared",
                options => options.StartsAt(2019100).IncrementsBy(1));

            /*
             * 
    CREATE SEQUENCE [shared].[InvoiceSequence]
    AS BIGINT
    START WITH 2019100
    INCREMENT BY 1;
             * */
            modelBuilder.Entity<Invoice>()
                .Property(i => i.InvoiceNumber)
                .HasDefaultValueSql("NEXT VALUE FOR shared.InvoiceSequence");
        }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
