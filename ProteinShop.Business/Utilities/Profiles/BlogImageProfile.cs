using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogImageDto;

namespace ProteinShop.Business.Utilities.Profiles;

public class BlogImageProfile : Profile
{
    public BlogImageProfile()
    {
        CreateMap<BlogImage, BlogImageGetDto>();
        CreateMap<BlogImageCreateDto, BlogImage>();
        CreateMap<BlogImageUpdateDto, BlogImage>();
    }
}