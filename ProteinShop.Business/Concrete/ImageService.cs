using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.ImageDto;

namespace ProteinShop.Business.Concrete;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IMapper _mapper;

    public ImageService(IImageRepository imageRepository, IMapper mapper)
    {
        _imageRepository = imageRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(ImageCreateDto ImageCreateDto)
    {
        Image Image = _mapper.Map<Image>(ImageCreateDto);
        if (Image is null)
        {
            return new ErrorResult(false, "not added");
        }
        await _imageRepository.AddAsync(Image);
        return new SuccessResult(true, "Added");
    }

    public async Task<IResult> DeleteAsync(Image Image)
    {
        if (Image is null)
        {
            return new ErrorResult(false, "not deleted");
        }
        await _imageRepository.DeleteAsync(Image);

        return new SuccessResult(true, "Deleted");
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        //    ProductGetDto productGetDto = await GetByIdAsync(id);
        //    Product product = _mapper.Map<Product>(productGetDto);
        //    if (product is not null)
        //    {
        //        await _imageRepository.DeleteAsync(product);
        //    }
        return null;
    }

    public async Task<IDataResult<List<ImageGetDto>>> GetAllAsync()
    {
        List<Image> Images = await _imageRepository.GetAllAsync(includes: new string[] { "Product" });

        return new SuccessDataResult<List<ImageGetDto>>(_mapper.Map<List<ImageGetDto>>(Images), "Images listed");

    }

    public async Task<IDataResult<ImageGetDto>> GetByIdAsync(int id)
    {
        Image Image = await _imageRepository.GetAsync(p => p.Id == id, new string[] { "Product" });

        return new SuccessDataResult<ImageGetDto>(_mapper.Map<ImageGetDto>(Image), true);
    }

    public async Task<IDataResult<bool>> IsExistsByIdAsync(int id)
    {
        return new SuccessDataResult<bool>(await _imageRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IResult> UpdateAsync(ImageUpdateDto ImageUpdateDto)
    {
        Image existsImage = await _imageRepository.GetAsync(p => p.Id == ImageUpdateDto.Id);

        if (existsImage is not null)
        {
            Image Image = _mapper.Map(ImageUpdateDto, existsImage);
            await _imageRepository.UpdateAsync(Image);
        }
        return new SuccessResult(true, "Updated");
    }
}
