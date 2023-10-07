using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> builder)
    {
        builder.Property(c=>c.Name).IsRequired(true).HasMaxLength(200);
        builder.HasMany(c => c.Products)
            .WithOne(p=>p.Catalog)
            .HasForeignKey(p => p.CatalogId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
