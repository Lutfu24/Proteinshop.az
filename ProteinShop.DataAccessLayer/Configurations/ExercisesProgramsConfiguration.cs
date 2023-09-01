using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Configurations;

public class ExercisesProgramsConfiguration : IEntityTypeConfiguration<ExercisesPrograms>
{
    public void Configure(EntityTypeBuilder<ExercisesPrograms> builder)
    {
        builder.Property(b => b.Name).IsRequired(true).HasMaxLength(200);
        builder.Property(b => b.Description).IsRequired(false).HasMaxLength(4000);
    }
}