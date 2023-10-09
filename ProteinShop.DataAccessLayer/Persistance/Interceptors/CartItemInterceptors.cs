using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProteinShop.Entities.Concrete;
using System.Security.Claims;

namespace ProteinShop.DataAccessLayer.Persistance.Interceptors;

public class CartItemInterceptors:SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartItemInterceptors(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateCartItem(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateCartItem(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateCartItem(DbContext context)
    {
        if (context is null) return;
        foreach (var entry in context.ChangeTracker.Entries<CartItem>())
        {
            entry.Entity.AppUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
