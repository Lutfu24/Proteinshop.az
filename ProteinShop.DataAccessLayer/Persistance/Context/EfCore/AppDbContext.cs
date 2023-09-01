using Microsoft.EntityFrameworkCore;
using ProteinShop.Entities.Concrete;
using System.Reflection;

namespace ProteinShop.DataAccessLayer.Persistance.Context.EfCore;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> op) : base(op){}

	public DbSet<Product> Products { get; set; } = null!;
	public DbSet<Brand> Brands { get; set; } = null!;
	public DbSet<Image> Images { get; set; } = null!;
	public DbSet<Accessories> Accessories { get; set; } = null!;
	public DbSet<Clothes> Clothes { get; set; } = null!;
	public DbSet<ExercisesPrograms> ExercisesPrograms { get; set; } = null!;
	public DbSet<Healths> Healths { get; set; } = null!;
	public DbSet<Nutritions> Nutritions { get; set; } = null!;
	public DbSet<OurAthletes> OurAthletes { get; set; } = null!;
	public DbSet<OurAthletesImages> OurAthletesImages { get; set; } = null!;
	public DbSet<ProductImages> ProductImages { get; set; } = null!;
	public DbSet<SportsEquipments> SportsEquipments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
