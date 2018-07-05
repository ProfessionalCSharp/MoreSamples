using System.Data.Entity;

namespace Wrox.ProCSharp.Entities
{
  public class MenuContext : DbContext
  {
    private const string connectionString = @"server=(localdb)\v11.0;database=WroxMenus2";
    public MenuContext()
      : base(connectionString)
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Menu>().Property(m => m.Price).HasColumnType("money");
      modelBuilder.Entity<Menu>().Property(m => m.Day).HasColumnType("date").IsOptional();
      modelBuilder.Entity<Menu>().Property(m => m.Text).HasMaxLength(40).IsRequired();
      modelBuilder.Entity<Menu>().HasRequired(m => m.MenuCard).WithMany(c => c.Menus).HasForeignKey(m => m.MenuCardId);

      modelBuilder.Entity<MenuCard>().Property(c => c.Text).HasMaxLength(30).IsRequired();
      modelBuilder.Entity<MenuCard>().HasMany(c => c.Menus).WithRequired().WillCascadeOnDelete();
    }

    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuCard> MenuCards { get; set; }
  }
}
