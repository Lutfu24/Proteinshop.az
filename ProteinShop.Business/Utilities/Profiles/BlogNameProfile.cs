using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogNameDto;

namespace ProteinShop.Business.Utilities.Profiles;

public class BlogNameProfile : Profile
{
    public BlogNameProfile()
    {
        CreateMap<BlogName, BlogNameGetDto>();
        CreateMap<BlogNameCreateDto, BlogName>();
        CreateMap<BlogNameUpdateDto, BlogName>();
    }
}
