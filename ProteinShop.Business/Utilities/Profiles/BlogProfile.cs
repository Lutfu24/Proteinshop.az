using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BlogDto;

namespace ProteinShop.Business.Utilities.Profiles;

public class BlogProfile:Profile
{
	public BlogProfile()
	{
		CreateMap<Blog, BlogGetDto>();
		CreateMap<BlogCreateDto, Blog>();
		CreateMap<BlogUpdateDto, Blog>();
    }
}
