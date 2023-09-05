﻿using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.Product;

namespace ProteinShop.Business.Concrete;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(ProductCreateDto productCreateDto)
    {
        Product product = _mapper.Map<Product>(productCreateDto);
        if (product is null)
        {
            return new ErrorResult(false, "not added");
        }
        await _productRepository.AddAsync(product);
        return new SuccessResult(true, "Added");
    }

    public async Task<IResult> DeleteAsync(Product product)
    {
        if (product is null)
        {
            return new ErrorResult(false,"not deleted");
        }
        await _productRepository.DeleteAsync(product);

        return new SuccessResult(true,"Deleted");
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        //    ProductGetDto productGetDto = await GetByIdAsync(id);
        //    Product product = _mapper.Map<Product>(productGetDto);
        //    if (product is not null)
        //    {
        //        await _productRepository.DeleteAsync(product);
        //    }
        return null;
    }

    public async Task<IDataResult<List<ProductGetDto>>> GetAllAsync()
    {
        List<Product> products = await _productRepository.GetAllAsync(includes: new string[] { "Brand" });

        return new SuccessDataResult<List<ProductGetDto>>(_mapper.Map<List<ProductGetDto>>(products), "Products listed");

    }

    public async Task<IDataResult<ProductGetDto>> GetByIdAsync(int id)
    {
        Product product = await _productRepository.GetAsync(p => p.Id == id, new string[] { "Brand" });

        return new SuccessDataResult<ProductGetDto>(_mapper.Map<ProductGetDto>(product), true);
    }

    public async Task<IDataResult<bool>> IsExistsByIdAsync(int id)
    {
        return new SuccessDataResult<bool>(await _productRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        Product existsProduct = await _productRepository.GetAsync(p => p.Id == productUpdateDto.Id);

        if (existsProduct is not null)
        {
            Product product = _mapper.Map(productUpdateDto, existsProduct);
            await _productRepository.UpdateAsync(product);
        }
        return new SuccessResult(true, "Updated");
    }
}
