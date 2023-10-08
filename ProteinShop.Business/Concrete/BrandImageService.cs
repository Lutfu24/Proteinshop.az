using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BrandImageDto;

namespace ProteinShop.Business.Concrete;

public class BrandImageService : IBrandImageService
{
    private readonly IBrandImageRepository _brandImageRepository;
    private readonly IMapper _mapper;

    public BrandImageService(IBrandImageRepository brandImageRepository, IMapper mapper)
    {
        _brandImageRepository = brandImageRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(BrandImageCreateDto BrandImageCreateDto)
    {
        BrandImage BrandImage = _mapper.Map<BrandImage>(BrandImageCreateDto);
        if (BrandImage is null)
        {
            return new ErrorResult(false, "not added");
        }
        await _brandImageRepository.AddAsync(BrandImage);
        return new SuccessResult(true, "Added");
    }

    public async Task<IResult> DeleteAsync(BrandImage BrandImage)
    {
        if (BrandImage is null)
        {
            return new ErrorResult(false, "not deleted");
        }
        await _brandImageRepository.DeleteAsync(BrandImage);

        return new SuccessResult(true, "Deleted");
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        //    ProductGetDto productGetDto = await GetByIdAsync(id);
        //    Product product = _mapper.Map<Product>(productGetDto);
        //    if (product is not null)
        //    {
        //        await _brandImageRepository.DeleteAsync(product);
        //    }
        return null;
    }

    public async Task<IDataResult<List<BrandImageGetDto>>> GetAllAsync()
    {
        List<BrandImage> BrandImages = await _brandImageRepository.GetAllAsync(includes: new string[] { "Brand" });

        return new SuccessDataResult<List<BrandImageGetDto>>(_mapper.Map<List<BrandImageGetDto>>(BrandImages), "BrandImages listed");

    }

    public async Task<IDataResult<BrandImageGetDto>> GetByIdAsync(int id)
    {
        BrandImage BrandImage = await _brandImageRepository.GetAsync(p => p.Id == id, new string[] { "Brand" });

        return new SuccessDataResult<BrandImageGetDto>(_mapper.Map<BrandImageGetDto>(BrandImage), true);
    }

    public async Task<IDataResult<bool>> IsExistsByIdAsync(int id)
    {
        return new SuccessDataResult<bool>(await _brandImageRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IResult> UpdateAsync(BrandImageUpdateDto BrandImageUpdateDto)
    {
        BrandImage existsBrandImage = await _brandImageRepository.GetAsync(p => p.Id == BrandImageUpdateDto.Id);

        if (existsBrandImage is not null)
        {
            BrandImage BrandImage = _mapper.Map(BrandImageUpdateDto, existsBrandImage);
            await _brandImageRepository.UpdateAsync(BrandImage);
        }
        return new SuccessResult(true, "Updated");
    }
}
