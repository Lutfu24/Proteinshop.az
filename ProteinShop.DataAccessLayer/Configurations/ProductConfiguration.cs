using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
        builder.Property(p => p.Price).IsRequired(true);
        builder.Property(p => p.Description).IsRequired(false).HasMaxLength(3000);
        builder.HasCheckConstraint("CK_Price_Product", "Price between 0 and 500");
        builder.HasCheckConstraint("CK_Raiting_Product", "Raiting between 0 and 5");
        builder.HasMany(p => p.ProductImages)
        .WithOne(pi => pi.Product)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
