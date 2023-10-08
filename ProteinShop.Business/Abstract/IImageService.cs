using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.ImageDto;

namespace ProteinShop.Business.Abstract;

public interface IImageService
{
    Task<IDataResult<List<ImageGetDto>>> GetAllAsync();
    Task<IDataResult<ImageGetDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(ImageCreateDto imageCreateDto);
    Task<IResult> UpdateAsync(ImageUpdateDto imageUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(Image image);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);
}