using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogNameDto;

namespace ProteinShop.Business.Abstract;

public interface IBlogNameService
{
    Task<IDataResult<List<BlogNameGetDto>>> GetAllAsync();
    Task<IDataResult<BlogNameGetDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(BlogNameCreateDto blogNameCreateDto);
    Task<IResult> UpdateAsync(BlogNameUpdateDto blogNameUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(BlogName blogName);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);
}