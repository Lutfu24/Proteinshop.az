using Core.DataAccess.Concrete.EfCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Concrete;

public class CartItemRepository : EfBaseRepository<CartItem, AppDbContext>, ICartItemRepository
{
    public CartItemRepository(AppDbContext context) : base(context)
    {
    }
}
