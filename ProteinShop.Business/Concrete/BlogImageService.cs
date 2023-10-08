using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogImageDto;

namespace ProteinShop.Business.Concrete;

public class BlogImageService : IBlogImageService
{

    private readonly IBlogImageRepository _blogImageRepository;
    private readonly IMapper _mapper;

    public BlogImageService(IBlogImageRepository blogImageRepository, IMapper mapper)
    {
        _blogImageRepository = blogImageRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(BlogImageCreateDto blogImageCreateDto)
    {
        BlogImage blogImage = _mapper.Map<BlogImage>(blogImageCreateDto);
        if (blogImage is null)
        {
            return new ErrorResult(false, "not added");
        }
        await _blogImageRepository.AddAsync(blogImage);
        return new SuccessResult(true, "Added");
    }

    public async Task<IResult> DeleteAsync(BlogImage blogImage)
    {
        if (blogImage is null)
        {
            return new ErrorResult(false, "not deleted");
        }
        await _blogImageRepository.DeleteAsync(blogImage);

        return new SuccessResult(true, "Deleted");
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        //    ProductGetDto productGetDto = await GetByIdAsync(id);
        //    Product product = _mapper.Map<Product>(productGetDto);
        //    if (product is not null)
        //    {
        //        await _blogImageRepository.DeleteAsync(product);
        //    }
        return null;
    }

    public async Task<IDataResult<List<BlogImageGetDto>>> GetAllAsync()
    {
        List<BlogImage> blogImages = await _blogImageRepository.GetAllAsync(includes: new string[] { "Blog" });

        return new SuccessDataResult<List<BlogImageGetDto>>(_mapper.Map<List<BlogImageGetDto>>(blogImages), "blog images listed");

    }

    public async Task<IDataResult<BlogImageGetDto>> GetByIdAsync(int id)
    {
        BlogImage blogImage = await _blogImageRepository.GetAsync(p => p.Id == id, new string[] { "Blog" });

        return new SuccessDataResult<BlogImageGetDto>(_mapper.Map<BlogImageGetDto>(blogImage), true);
    }

    public async Task<IDataResult<bool>> IsExistsByIdAsync(int id)
    {
        return new SuccessDataResult<bool>(await _blogImageRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IResult> UpdateAsync(BlogImageUpdateDto blogImageUpdateDto)
    {
        BlogImage existsBlogImage = await _blogImageRepository.GetAsync(p => p.Id == blogImageUpdateDto.Id);

        if (existsBlogImage is not null)
        {
            BlogImage blogImage = _mapper.Map(blogImageUpdateDto, existsBlogImage);
            await _blogImageRepository.UpdateAsync(blogImage);
        }
        return new SuccessResult(true, "Updated");
    }
}
