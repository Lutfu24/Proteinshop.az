using Core.DataAccess.Abstract;
using ProteinShop.Entities.Concrete;
using System.Linq.Expressions;

namespace ProteinShop.DataAccessLayer.Abstract;

public interface IProductRepository:IRepository<Product>
{
}
