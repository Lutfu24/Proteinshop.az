using Core.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Concrete;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.DataAccessLayer.Persistance.Interceptors;

namespace ProteinShop.DataAccessLayer;

public static class DataAccessConfiguration
{
	public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(op =>
		{
			op.UseSqlServer(configuration.GetConnectionString("Default"));
		});
		services.AddHttpContextAccessor();
		services.AddScoped<BaseAuditableEntityInterceptor>();
		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IBrandRepository, BrandRepository>();
		services.AddScoped<IImageRepository, ImageRepository>();
		services.AddScoped<IBrandImageRepository, BrandImageRepository>();
		services.AddScoped<IBlogRepository, BlogRepository>();
		services.AddScoped<IBlogNameRepository, BlogNameRepository>();
		services.AddScoped<IBlogImageRepository, BlogImageRepository>();
		services.AddScoped<ICatalogRepository, CatalogRepository>();
        services.AddIdentity<AppUser, IdentityRole>(op =>
		{
			op.User.RequireUniqueEmail = true;

			op.Password.RequiredLength = 8;

			op.Lockout.MaxFailedAccessAttempts = 5;
			op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
		}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
		return services;
	}
}
