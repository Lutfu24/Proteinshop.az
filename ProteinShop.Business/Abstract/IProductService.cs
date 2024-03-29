﻿using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.ProductDto;

namespace ProteinShop.Business.Abstract;

public interface IProductService
{
    Task<IDataResult<List<ProductGetDto>>> GetAllAsync();
    Task<IDataResult<ProductGetDto>> GetByIdAsync(int id);
    Task<IDataResult<List<ProductGetDto>>> GetFilterBest(bool isBestSeller);
    Task<IDataResult<List<ProductGetDto>>> GetFilterNew(bool isNew);
    Task<IDataResult<List<ProductGetDto>>> GetFilterDiscount();
    Task<IResult> AddAsync(ProductCreateDto productCreateDto);
    Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(ProductDeleteDto product);
    Task<IDataResult<bool>> IsExistsByIdAsync(int id);

}
