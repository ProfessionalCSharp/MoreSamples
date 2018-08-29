using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static SeedSample.MenusContext.ColumnNames;

namespace SeedSample
{
    public class MenusContext : DbContext
    {
        public static class ColumnNames
        {
            public const string LastUpdated = nameof(LastUpdated);
        }

        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=Restaurant1;trusted_connection=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // shadow state
            modelBuilder.Entity<MenuItem>().Property<DateTime>(LastUpdated);

            modelBuilder.Entity<MenuItem>().Property(m => m.Text).IsRequired().HasMaxLength(40);

            // use anonymous types to pass shadow state information
            modelBuilder.Entity<MenuItem>().HasData(
                new { MenuItemId = 1, Text = "Wiener Schnitzel mit Kartoffelsalat", MenuDate = new DateTime(2018, 8, 27), LastUpdated = DateTime.Now },
                new { MenuItemId = 2, Text = "Faschierter Braten mit Karoffelpüree", MenuDate = new DateTime(2018, 8, 28), LastUpdated = DateTime.Now });
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            foreach (var item in ChangeTracker.Entries<Book>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                item.CurrentValues[LastUpdated] = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges() => SaveChangesAsync().Result;
    }
}
