using Core.DataAccess.Concrete.EfCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Concrete;

public class ImageRepository : EfBaseRepository<Image, AppDbContext>, IImageRepository
{
    public ImageRepository(AppDbContext context) : base(context)
    {
    }
}
