using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.Product;

namespace ProteinShop.Business.Abstract;

public interface IProductService
{
    Task<List<ProductGetDto>> GetAllAsync();
    Task<ProductGetDto> GetByIdAsync(int id);
    Task AddAsync(ProductCreateDto productCreateDto);
    Task UpdateAsync(ProductUpdateDto productUpdateDto);
    Task DeleteByIdAsync(int id);
    Task DeleteAsync(Product product);
    Task<bool> IsExistsByIdAsync(int id);

}
