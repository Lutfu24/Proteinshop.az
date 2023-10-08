using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.CatalogDto;

namespace ProteinShop.Business.Concrete;

public class CatalogService : ICatalogService
{
    private readonly ICatalogRepository _catalogRepository;
    private readonly IMapper _mapper;

    public CatalogService(ICatalogRepository catalogRepository, IMapper mapper)
    {
        _catalogRepository = catalogRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(CatalogCreateDto CatalogCreateDto)
    {
        Catalog Catalog = _mapper.Map<Catalog>(CatalogCreateDto);
        if (Catalog is null)
        {
            return new ErrorResult(false, "not added");
        }
        await _catalogRepository.AddAsync(Catalog);
        return new SuccessResult(true, "Added");
    }

    public async Task<IResult> DeleteAsync(Catalog Catalog)
    {
        if (Catalog is null)
        {
            return new ErrorResult(false, "not deleted");
        }
        await _catalogRepository.DeleteAsync(Catalog);

        return new SuccessResult(true, "Deleted");
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        //    ProductGetDto productGetDto = await GetByIdAsync(id);
        //    Product product = _mapper.Map<Product>(productGetDto);
        //    if (product is not null)
        //    {
        //        await _catalogRepository.DeleteAsync(product);
        //    }
        return null;
    }

    public async Task<IDataResult<List<CatalogGetDto>>> GetAllAsync()
    {
        List<Catalog> Catalogs = await _catalogRepository.GetAllAsync(includes: new string[] { "Products" });

        return new SuccessDataResult<List<CatalogGetDto>>(_mapper.Map<List<CatalogGetDto>>(Catalogs), "Catalogs listed");

    }

    public async Task<IDataResult<CatalogGetDto>> GetByIdAsync(int id)
    {
        Catalog Catalog = await _catalogRepository.GetAsync(p => p.Id == id, new string[] { "Products" });

        return new SuccessDataResult<CatalogGetDto>(_mapper.Map<CatalogGetDto>(Catalog), true);
    }

    public async Task<IDataResult<bool>> IsExistsByIdAsync(int id)
    {
        return new SuccessDataResult<bool>(await _catalogRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IResult> UpdateAsync(CatalogUpdateDto CatalogUpdateDto)
    {
        Catalog existsCatalog = await _catalogRepository.GetAsync(p => p.Id == CatalogUpdateDto.Id);

        if (existsCatalog is not null)
        {
            Catalog Catalog = _mapper.Map(CatalogUpdateDto, existsCatalog);
            await _catalogRepository.UpdateAsync(Catalog);
        }
        return new SuccessResult(true, "Updated");
    }
}
