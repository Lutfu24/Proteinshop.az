using Core.DataAccess.Concrete.EfCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Concrete;

public class BrandImageRepository : EfBaseRepository<BrandImage, AppDbContext>, IBrandImageRepository
{
    public BrandImageRepository(AppDbContext context) : base(context)
    {
    }
}
