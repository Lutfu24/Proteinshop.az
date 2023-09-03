using Core.Utilities.DataAccess.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.DataAccessLayer.Persistance.Context.EfCore;
using ProteinShop.Entities.Concrete;
using System.Linq.Expressions;

namespace ProteinShop.DataAccessLayer.Concrete;

public class ProductRepository : EfBaseRepository<Product, AppDbContext>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}