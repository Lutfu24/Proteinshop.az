using Core.DataAccess.Concrete.EfCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Concrete;

public class BlogNameRepository : EfBaseRepository<BlogName, AppDbContext>, IBlogNameRepository
{
    public BlogNameRepository(AppDbContext context) : base(context)
    {
    }
}
