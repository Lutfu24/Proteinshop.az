using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogDto;

namespace ProteinShop.Business.Concrete;

public class BlogService:IBlogService
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public BlogService(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(BlogCreateDto blogCreateDto)
    {
        Blog blog = _mapper.Map<Blog>(blogCreateDto);
        if (blog is null)
        {
            return new ErrorResult(false, "not added");
        }
        await _blogRepository.AddAsync(blog);
        return new SuccessResult(true, "Added");
    }

    public async Task<IResult> DeleteAsync(Blog blog)
    {
        if (blog is null)
        {
            return new ErrorResult(false, "not deleted");
        }
        await _blogRepository.DeleteAsync(blog);

        return new SuccessResult(true, "Deleted");
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        //    ProductGetDto productGetDto = await GetByIdAsync(id);
        //    Product product = _mapper.Map<Product>(productGetDto);
        //    if (product is not null)
        //    {
        //        await _blogRepository.DeleteAsync(product);
        //    }
        return null;
    }

    public async Task<IDataResult<List<BlogGetDto>>> GetAllAsync()
    {
        List<Blog> blogs = await _blogRepository.GetAllAsync(includes: new string[] { "BlogName", "BlogImages" });

        return new SuccessDataResult<List<BlogGetDto>>(_mapper.Map<List<BlogGetDto>>(blogs), "blogs listed");

    }

    public async Task<IDataResult<BlogGetDto>> GetByIdAsync(int id)
    {
        Blog blog = await _blogRepository.GetAsync(p => p.Id == id, new string[] { "BlogName", "BlogImages" });

        return new SuccessDataResult<BlogGetDto>(_mapper.Map<BlogGetDto>(blog), true);
    }

    public async Task<IDataResult<bool>> IsExistsByIdAsync(int id)
    {
        return new SuccessDataResult<bool>(await _blogRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IResult> UpdateAsync(BlogUpdateDto blogUpdateDto)
    {
        Blog existsBlog = await _blogRepository.GetAsync(p => p.Id == blogUpdateDto.Id);

        if (existsBlog is not null)
        {
            Blog blog = _mapper.Map(blogUpdateDto, existsBlog);
            await _blogRepository.UpdateAsync(blog);
        }
        return new SuccessResult(true, "Updated");
    }
}
