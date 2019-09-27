using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsyncStreamSample
{
    public class SomeDataContext : DbContext
    {
        public SomeDataContext(DbContextOptions<SomeDataContext> options)
            : base(options)
        {

        }
        public DbSet<SomeData> SomeData { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SomeData>()
                .Property(d => d.Text)
                .IsRequired()
                .HasMaxLength(20);

            var data = Enumerable.Range(1, 10000)
                .Select(i => new SomeData { SomeDataId = i, Number = i * 4, Text = $"a text for {i}" });
            modelBuilder.Entity<SomeData>().HasData(data.ToArray());
        }
    }
}
