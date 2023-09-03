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
		return services;
	}
}
