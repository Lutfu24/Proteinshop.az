using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete.EfCore;

public abstract class EfBaseRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext
{
    private readonly TContext _context;

    public EfBaseRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = GetQuery();
        query = AddIncludeToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();
        return expression != null
            ? query.Where(expression).FirstOrDefaultAsync(cancellationToken)
            : query.FirstOrDefaultAsync(cancellationToken);
    }
    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = GetQuery();
        query = AddIncludeToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();
        return expression != null
            ? query.Where(expression).ToListAsync(cancellationToken)
            : query.ToListAsync(cancellationToken);
    }

    public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = GetQuery();

        return await query.AnyAsync(expression, cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
    private DbSet<TEntity> GetQuery()
    {
        return _context.Set<TEntity>();
    }
    private static IQueryable<TEntity> AddIncludeToQuery(string[] includes, IQueryable<TEntity> query)
    {
        foreach (string include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}
