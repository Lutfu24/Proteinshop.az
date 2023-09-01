using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class SportsEquipmentsConfiguration : IEntityTypeConfiguration<SportsEquipments>
{
    public void Configure(EntityTypeBuilder<SportsEquipments> builder)
    {
        builder.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
        builder.Property(p => p.Price).IsRequired(true);
        builder.HasCheckConstraint("CK_Price_SportsEquipments", "Price between 0 and 500");
        builder.HasCheckConstraint("CK_Raiting_SportsEquipments", "Raiting between 0 and 5");
    }
}
