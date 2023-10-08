using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BrandDto;

namespace ProteinShop.Business.Abstract;

public interface IBrandService
{
    Task<IDataResult<List<BrandGetDto>>> GetAllAsync();
    Task<IDataResult<BrandGetDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(BrandCreateDto brandCreateDto);
    Task<IResult> UpdateAsync(BrandUpdateDto brandUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(Brand brand);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);
}
