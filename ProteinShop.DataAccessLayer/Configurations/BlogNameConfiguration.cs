using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class BlogNameConfiguration : IEntityTypeConfiguration<BlogName>
{
    public void Configure(EntityTypeBuilder<BlogName> builder)
    {
        builder.Property(b => b.Name).IsRequired(true).HasMaxLength(200);
        builder.HasMany(b => b.Blogs)
            .WithOne(p => p.BlogName)
            .HasForeignKey(p => p.BlogNameId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
