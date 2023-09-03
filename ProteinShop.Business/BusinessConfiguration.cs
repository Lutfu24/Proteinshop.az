using Microsoft.Extensions.DependencyInjection;
using ProteinShop.Business.Abstract;
using ProteinShop.Business.Concrete;
using System.Reflection;

namespace ProteinShop.Business;

public static class BusinessConfiguration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
