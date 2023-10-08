using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BrandImageDto;

namespace ProteinShop.Business.Utilities.Profiles;

public class BrandImageProfile:Profile
{
	public BrandImageProfile()
	{
		CreateMap<BrandImage, BrandImageGetDto>();
	}
}
