using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(b => b.Name).IsRequired(true).HasMaxLength(100);
        builder.HasMany(b => b.Products)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(b => b.SportsEquipments)
            .WithOne(s => s.Brand)
            .HasForeignKey(s => s.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(b => b.Clothes)
            .WithOne(c => c.Brand)
            .HasForeignKey(c => c.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}