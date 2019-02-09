using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LazyLoading
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(a => a.WrittenBooks)
                .WithOne(nameof(Book.Author))
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(r => r.ReviewedBooks)
                .WithOne(nameof(Book.Reviewer))
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.EditedBooks)
                .WithOne(nameof(Book.Editor))
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
