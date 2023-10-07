using Core.DataAccess.Concrete.EfCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Concrete;

public class BlogRepository : EfBaseRepository<Blog, AppDbContext>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    {
    }
}
