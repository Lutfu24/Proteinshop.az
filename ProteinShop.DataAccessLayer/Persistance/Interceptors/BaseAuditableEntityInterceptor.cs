using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProteinShop.Entities.Concrete.Common;

namespace ProteinShop.DataAccessLayer.Persistance.Interceptors;

public class BaseAuditableEntityInterceptor:SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BaseAuditableEntityInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntity(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntity(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    void UpdateEntity(DbContext context)
    {
        if (context is null) return;
        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State==EntityState.Added)
            {
                entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User.Identity!.Name!;
                entry.Entity.CreatedAt = DateTime.Now;
            }
            else if (entry.State==EntityState.Modified)
            {
                entry.Entity.ModifiedBy = _httpContextAccessor.HttpContext.User.Identity!.Name!;
                entry.Entity.ModifiedAt = DateTime.Now;
            }
        }
    }
}
