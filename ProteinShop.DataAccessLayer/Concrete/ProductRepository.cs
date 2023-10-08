using Core.DataAccess.Concrete.EfCore;
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

    public async Task<List<Product>> GetFilterBest(bool isBestSeller)
    {
        List<Product> products = await GetAllAsync(p=>p.IsBestSeller==isBestSeller, new string[] { "Brand", "Catalog", "Images" });
    
        return products;
    }
    public async Task<List<Product>> GetFilterNew(bool isNew)
    {
        List<Product> products = await GetAllAsync(p => p.IsNew == isNew, new string[] { "Brand", "Catalog", "Images" });

        return products;
    }
    public async Task<List<Product>> GetFilterDiscount()
    {
        List<Product> products = await GetAllAsync(p => p.Discount != 0, new string[] { "Brand", "Catalog", "Images" });

        return products;
    }
}
