using Microsoft.EntityFrameworkCore;

namespace SeedSample
{
    public class F1Context : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\MSSQLLocalDb;database=Formula1;trusted_connection=true";
        public DbSet<Racer> Racers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Racer>().Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Racer>().Property(r => r.Team)
                .IsRequired(false)
                .HasMaxLength(60);

            modelBuilder.Entity<Racer>().HasData(
                new Racer { Id = 1, Name = "Lewis Hamilton", Team = "Mercedes", Points = 231 },
                new Racer { Id = 2, Name = "Sebastian Vettel", Team = "Ferrari", Points = 214 },
                new Racer { Id = 3, Name = "Kimi Räikkönen", Team = "Ferrari", Points = 146 },
                new Racer { Id = 4, Name = "Valtteri Bottas", Team = "Mercedes", Points = 144 },
                new Racer { Id = 5, Name = "Max Verstappen", Team = "Red Bull Racing", Points = 120 },
                new Racer { Id = 6, Name = "Daniel Ricciardo", Team = "Red Bull Racing", Points = 118 }
            );
        }
    }
}
