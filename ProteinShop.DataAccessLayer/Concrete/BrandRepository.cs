using Core.Utilities.DataAccess.Concrete.EfCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Concrete;

public class BrandRepository : EfBaseRepository<Brand, AppDbContext>, IBrandRepository
{
    public BrandRepository(AppDbContext context) : base(context)
    {
    }
}
