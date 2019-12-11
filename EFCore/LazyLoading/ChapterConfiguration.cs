using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LazyLoading
{
    internal class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.HasOne(c => c.Book)
                .WithMany(b => b!.Chapters)
                .HasForeignKey(c => c.BookId);
        }
    }
}
