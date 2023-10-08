using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogNameDto;

namespace ProteinShop.Business.Concrete;

public class BlogNameService : IBlogNameService
{
    private readonly IBlogNameRepository _blogNameRepository;
    private readonly IMapper _mapper;

    public BlogNameService(IBlogNameRepository blogNameRepository, IMapper mapper)
    {
        _blogNameRepository = blogNameRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(BlogNameCreateDto blogNameCreateDto)
    {
        BlogName blogName = _mapper.Map<BlogName>(blogNameCreateDto);
        if (blogName is null)
        {
            return new ErrorResult(false, "not added");
        }
        await _blogNameRepository.AddAsync(blogName);
        return new SuccessResult(true, "Added");
    }

    public async Task<IResult> DeleteAsync(BlogName blogName)
    {
        if (blogName is null)
        {
            return new ErrorResult(false, "not deleted");
        }
        await _blogNameRepository.DeleteAsync(blogName);

        return new SuccessResult(true, "Deleted");
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        //    ProductGetDto productGetDto = await GetByIdAsync(id);
        //    Product product = _mapper.Map<Product>(productGetDto);
        //    if (product is not null)
        //    {
        //        await _blogNameRepository.DeleteAsync(product);
        //    }
        return null;
    }

    public async Task<IDataResult<List<BlogNameGetDto>>> GetAllAsync()
    {
        List<BlogName> blogNames = await _blogNameRepository.GetAllAsync(includes: new string[] { "Blogs" });

        return new SuccessDataResult<List<BlogNameGetDto>>(_mapper.Map<List<BlogNameGetDto>>(blogNames), "blog Names listed");

    }

    public async Task<IDataResult<BlogNameGetDto>> GetByIdAsync(int id)
    {
        BlogName blogName = await _blogNameRepository.GetAsync(p => p.Id == id, new string[] { "Blogs" });

        return new SuccessDataResult<BlogNameGetDto>(_mapper.Map<BlogNameGetDto>(blogName), true);
    }

    public async Task<IDataResult<bool>> IsExistsByIdAsync(int id)
    {
        return new SuccessDataResult<bool>(await _blogNameRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IResult> UpdateAsync(BlogNameUpdateDto blogNameUpdateDto)
    {
        BlogName existsBlogName = await _blogNameRepository.GetAsync(p => p.Id == blogNameUpdateDto.Id);

        if (existsBlogName is not null)
        {
            BlogName blogName = _mapper.Map(blogNameUpdateDto, existsBlogName);
            await _blogNameRepository.UpdateAsync(blogName);
        }
        return new SuccessResult(true, "Updated");
    }
}
