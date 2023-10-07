using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BrandDto;

namespace ProteinShop.Business.Utilities.Profiles;

public class BrandProfile:Profile
{
	public BrandProfile()
	{
		CreateMap<Brand, BrandGetDto>();
	}
}
