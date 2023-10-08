using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BrandDto;

namespace ProteinShop.Business.Concrete;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public BrandService(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(BrandCreateDto brandCreateDto)
    {
        Brand brand = _mapper.Map<Brand>(brandCreateDto);
        if (brand is null)
        {
            return new ErrorResult(false, "not added");
        }
        await _brandRepository.AddAsync(brand);
        return new SuccessResult(true, "Added");
    }

    public async Task<IResult> DeleteAsync(Brand brand)
    {
        if (brand is null)
        {
            return new ErrorResult(false, "not deleted");
        }
        await _brandRepository.DeleteAsync(brand);

        return new SuccessResult(true, "Deleted");
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        //    ProductGetDto productGetDto = await GetByIdAsync(id);
        //    Product product = _mapper.Map<Product>(productGetDto);
        //    if (product is not null)
        //    {
        //        await _brandRepository.DeleteAsync(product);
        //    }
        return null;
    }

    public async Task<IDataResult<List<BrandGetDto>>> GetAllAsync()
    {
        List<Brand> brands = await _brandRepository.GetAllAsync(includes: new string[] { "Products", "BrandImages" });

        return new SuccessDataResult<List<BrandGetDto>>(_mapper.Map<List<BrandGetDto>>(brands), "Products listed");

    }

    public async Task<IDataResult<BrandGetDto>> GetByIdAsync(int id)
    {
        Brand brand = await _brandRepository.GetAsync(p => p.Id == id, new string[] { "Products", "BrandImages" });

        return new SuccessDataResult<BrandGetDto>(_mapper.Map<BrandGetDto>(brand), true);
    }

    public async Task<IDataResult<bool>> IsExistsByIdAsync(int id)
    {
        return new SuccessDataResult<bool>(await _brandRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IResult> UpdateAsync(BrandUpdateDto brandUpdateDto)
    {
        Brand existsBrand = await _brandRepository.GetAsync(p => p.Id == brandUpdateDto.Id);

        if (existsBrand is not null)
        {
            Brand brand = _mapper.Map(brandUpdateDto, existsBrand);
            await _brandRepository.UpdateAsync(brand);
        }
        return new SuccessResult(true, "Updated");
    }
}
