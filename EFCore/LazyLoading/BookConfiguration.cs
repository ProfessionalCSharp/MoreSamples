using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LazyLoading
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(b => b.Chapters)
                .WithOne(c => c.Book!)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.Author)
                .WithMany(a => a!.WrittenBooks)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Reviewer)
                .WithMany(r => r!.ReviewedBooks)
                .HasForeignKey(b => b.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Editor)
                .WithMany(e => e!.EditedBooks)
                .HasForeignKey(e => e.EditorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(b => b.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(b => b.Publisher)
                .HasMaxLength(30)
                .IsRequired(false);
        }
    }
}
