using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnumMapping
{
    public class SomeDataContext : DbContext
    {
        public SomeDataContext(DbContextOptions<SomeDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SomeData>()
                .Property(d => d.CustomValue)
                .HasConversion(d => d.ToString(), d => Enum.Parse<CustomValues>(d));

            modelBuilder.Entity<SomeData>()
                .Property(d => d.Text).HasMaxLength(20);

            modelBuilder.Entity<SomeData>()
                .HasData(
                    new SomeData
                    {
                        SomeDataId = 1,
                        Text = "hello",
                        CustomValue = CustomValues.One
                    },
                    new SomeData
                    {
                        SomeDataId = 2,
                        Text = "world",
                        CustomValue = CustomValues.Two
                    });

            modelBuilder.Entity<LookupValue>()
                .Property(l => l.CustomValue)
                .HasConversion(l => l.ToString(), l => Enum.Parse<CustomValues>(l));

            modelBuilder.Entity<LookupValue>()
                .HasMany(l => l.SomeData2)
                .WithOne()
                .HasForeignKey("LookupValueId")
                .OnDelete(DeleteBehavior.SetNull);

            LookupValue[] lookups = new[]
            {
                new LookupValue
                {
                    LookupValueId = 1,
                    CustomValue = CustomValues.One
                },
                new LookupValue
                {
                    LookupValueId = 2,
                    CustomValue = CustomValues.Two
                },
                new LookupValue
                {
                    LookupValueId = 3,
                    CustomValue = CustomValues.Three
                }
            };
            modelBuilder.Entity<LookupValue>()
                .HasData(lookups);

            // relation
            modelBuilder.Entity<SomeData2>()
                .HasOne<LookupValue>("LookupValue")
                .WithMany(l => l.SomeData2)
                .HasForeignKey("LookupValueId");

            modelBuilder.Entity<SomeData2>()
                 .HasData(
                    new
                    {
                        SomeData2Id = 1,
                        Text = "hello",
                        lookups[0].LookupValueId,
                        CustomValue = lookups[0]
                    },
                    new
                    {
                        SomeData2Id = 2,
                        Text = "world",
                        lookups[1].LookupValueId,
                        CustomValue = lookups[1]
                    }
                );

        }

        public DbSet<SomeData> SampleData { get; set; } = default!;
        internal DbSet<LookupValue> LookupValues { get; set; } = default!;
        public DbSet<SomeData2> SomeData2 { get; set; } = default!;
    }
}
