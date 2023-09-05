using Core.Utilities.Security.JWT;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProteinShop.Business.Abstract;
using ProteinShop.Business.Concrete;
using System.Reflection;

namespace ProteinShop.Business;

public static class BusinessConfiguration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenHelper, JWTHelper>();

        return services;
    }
}
