using AutoMapper;
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

    public async Task AddAsync(ProductCreateDto productCreateDto)
    {
        Product product = _mapper.Map<Product>(productCreateDto);
        if (product is not null)
        {
            await _productRepository.AddAsync(product);
        }
    }

    public async Task DeleteAsync(Product product)
    {
        if (product is not null)
        {
            await _productRepository.DeleteAsync(product);
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        ProductGetDto productGetDto = await GetByIdAsync(id);
        Product product = _mapper.Map<Product>(productGetDto);
        if (product is not null)
        {
            await _productRepository.DeleteAsync(product);
        }
    }

    public async Task<List<ProductGetDto>> GetAllAsync()
    {
        List<Product> products = await _productRepository.GetAllAsync(includes: new string[] { "Brand" });

        return _mapper.Map<List<ProductGetDto>>(products);
        
    }

    public async Task<ProductGetDto> GetByIdAsync(int id)
    {
        Product product = await _productRepository.GetAsync(p => p.Id == id, new string[] { "Brand" });

        return _mapper.Map<ProductGetDto>(product);
    }

    public async Task<bool> IsExistsByIdAsync(int id)
    {
        return await _productRepository.IsExistsAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        Product existsProduct = await _productRepository.GetAsync(p => p.Id == productUpdateDto.Id);

        if (existsProduct is not null)
        {
            Product product = _mapper.Map(productUpdateDto, existsProduct);
            await _productRepository.UpdateAsync(product);
        }
    }
}
