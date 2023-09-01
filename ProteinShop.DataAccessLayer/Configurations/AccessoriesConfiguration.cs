using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class AccessoriesConfiguration : IEntityTypeConfiguration<Accessories>
{
    public void Configure(EntityTypeBuilder<Accessories> builder)
    {
        builder.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
        builder.Property(p => p.Price).IsRequired(true);
        builder.HasCheckConstraint("CK_Price_Accessories", "Price between 0 and 500");
        builder.HasCheckConstraint("CK_Raiting_Accessories", "Raiting between 0 and 5");
    }
}