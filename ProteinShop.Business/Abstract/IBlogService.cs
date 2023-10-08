using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogDto;

namespace ProteinShop.Business.Abstract;

public interface IBlogService
{
    Task<IDataResult<List<BlogGetDto>>> GetAllAsync();
    Task<IDataResult<BlogGetDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(BlogCreateDto blogCreateDto);
    Task<IResult> UpdateAsync(BlogUpdateDto blogUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(Blog blog);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);
}