using Core.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProteinShop.DataAccessLayer.Persistance.Interceptors;
using ProteinShop.Entities.Concrete;
using System.Reflection;

namespace ProteinShop.DataAccessLayer.Persistance.Context.EfCore;

public class AppDbContext:IdentityDbContext<AppUser>
{
	private readonly BaseAuditableEntityInterceptor _baseAuditableEntityInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> op, BaseAuditableEntityInterceptor baseAuditableEntityInterceptor) : base(op)
    {
        _baseAuditableEntityInterceptor = baseAuditableEntityInterceptor;
    }

    public DbSet<Product> Products { get; set; } = null!;
	public DbSet<Brand> Brands { get; set; } = null!;
	public DbSet<Image> Images { get; set; } = null!;
	public DbSet<Blog> Blogs { get; set; } = null!;
	public DbSet<BlogImage> BlogImages { get; set; } = null!;
	public DbSet<BlogName> BlogNames { get; set; } = null!;
	public DbSet<Catalog> Catalogs { get; set; } = null!;
	public DbSet<BrandImage> BrandImages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_baseAuditableEntityInterceptor);
        optionsBuilder.UseSqlServer(@"Server=LAPTOP-9SQPT65L;Database=ProteinShopProjectDb;Trusted_Connection=true;");
        base.OnConfiguring(optionsBuilder);
    }
}
