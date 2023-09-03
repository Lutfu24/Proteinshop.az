using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.Product;

namespace ProteinShop.Business.Utilities.Profiles;

public class ProductProfile:Profile
{
	public ProductProfile()
	{
		CreateMap<ProductGetDto, Product>().ReverseMap();
		CreateMap<ProductCreateDto, Product>();
		CreateMap<ProductUpdateDto, Product>();
    }
}
