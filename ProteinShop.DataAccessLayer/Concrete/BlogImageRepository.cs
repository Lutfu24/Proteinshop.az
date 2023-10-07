using Core.DataAccess.Concrete.EfCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Concrete;

public class BlogImageRepository : EfBaseRepository<BlogImage, AppDbContext>, IBlogImageRepository
{
    public BlogImageRepository(AppDbContext context) : base(context)
    {
    }
}
