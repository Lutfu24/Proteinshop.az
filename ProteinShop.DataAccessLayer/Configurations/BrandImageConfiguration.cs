using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class BrandImageConfiguration : IEntityTypeConfiguration<BrandImage>
{
    public void Configure(EntityTypeBuilder<BrandImage> builder)
    {
        builder.Property(i => i.Path).IsRequired(true).HasMaxLength(300);
    }
}
