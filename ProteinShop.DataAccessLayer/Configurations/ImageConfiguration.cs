using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.Property(b => b.Name).IsRequired(true).HasMaxLength(100);
        builder.HasMany(i=>i.Accessories)
        .WithOne(a => a.Image)
            .HasForeignKey(a => a.ImageId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(i => i.Clothes)
        .WithOne(c => c.Image)
            .HasForeignKey(c => c.ImageId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(i => i.ExercisesPrograms)
        .WithOne(e => e.Image)
            .HasForeignKey(e => e.ImageId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(i => i.Healths)
        .WithOne(h => h.Image)
            .HasForeignKey(h => h.ImageId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(i => i.Nutritions)
        .WithOne(n => n.Image)
            .HasForeignKey(n => n.ImageId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(i => i.SportsEquipments)
        .WithOne(s => s.Image)
            .HasForeignKey(s => s.ImageId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(i => i.ProductImages)
        .WithOne(pi => pi.Image)
            .HasForeignKey(pi => pi.ImageId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
