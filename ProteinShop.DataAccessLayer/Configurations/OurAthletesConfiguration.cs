using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class OurAthletesConfiguration : IEntityTypeConfiguration<OurAthletes>
{
    public void Configure(EntityTypeBuilder<OurAthletes> builder)
    {
        builder.Property(b => b.Name).IsRequired(true).HasMaxLength(100);
    }
}
