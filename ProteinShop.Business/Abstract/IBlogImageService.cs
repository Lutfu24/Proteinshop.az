using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogImageDto;

namespace ProteinShop.Business.Abstract;

public interface IBlogImageService
{
    Task<IDataResult<List<BlogImageGetDto>>> GetAllAsync();
    Task<IDataResult<BlogImageGetDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(BlogImageCreateDto blogImageCreateDto);
    Task<IResult> UpdateAsync(BlogImageUpdateDto blogImageUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(BlogImage blogImage);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);
}