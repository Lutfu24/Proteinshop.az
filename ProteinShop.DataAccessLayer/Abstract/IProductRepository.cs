using Core.DataAccess.Abstract;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.DataAccessLayer.Abstract;

public interface IProductRepository:IRepository<Product>
{
    Task<List<Product>> GetFilterBest(bool isBestSeller);
    Task<List<Product>> GetFilterNew(bool isNew);
    Task<List<Product>> GetFilterDiscount();
}