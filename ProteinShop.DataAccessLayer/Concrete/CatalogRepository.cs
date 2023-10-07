using Core.DataAccess.Concrete.EfCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Concrete;

public class CatalogRepository : EfBaseRepository<Catalog, AppDbContext>, ICatalogRepository
{
    public CatalogRepository(AppDbContext context) : base(context)
    {
    }
}