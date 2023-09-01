using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class HealthsConfiguration : IEntityTypeConfiguration<Healths>
{
    public void Configure(EntityTypeBuilder<Healths> builder)
    {
        builder.Property(b => b.Name).IsRequired(true).HasMaxLength(100);
        builder.Property(b => b.Description).IsRequired(false).HasMaxLength(3000);
    }
}