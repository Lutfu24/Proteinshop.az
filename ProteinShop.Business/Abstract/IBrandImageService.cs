using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BrandImageDto;

namespace ProteinShop.Business.Abstract;

public interface IBrandImageService
{
    Task<IDataResult<List<BrandImageGetDto>>> GetAllAsync();
    Task<IDataResult<BrandImageGetDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(BrandImageCreateDto brandImageCreateDto);
    Task<IResult> UpdateAsync(BrandImageUpdateDto brandImageUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(BrandImage brandImage);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);
}
