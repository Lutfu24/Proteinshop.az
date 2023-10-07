using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.ProductDto;

namespace ProteinShop.Business.Abstract;

public interface IProductService
{
    Task<IDataResult<List<ProductGetDto>>> GetAllAsync();
    Task<IDataResult<ProductGetDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(ProductCreateDto productCreateDto);
    Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(Product product);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);

}
