using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.CatalogDto;

namespace ProteinShop.Business.Abstract;

public interface ICatalogService
{
    Task<IDataResult<List<CatalogGetDto>>> GetAllAsync();
    Task<IDataResult<CatalogGetDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(CatalogCreateDto catalogCreateDto);
    Task<IResult> UpdateAsync(CatalogUpdateDto catalogUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(Catalog catalog);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);
}