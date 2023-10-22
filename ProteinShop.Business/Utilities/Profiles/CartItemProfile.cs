using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.CartItemDto;

namespace ProteinShop.Business.Utilities.Profiles;

public class CartItemProfile:Profile
{
	public CartItemProfile()
	{
		CreateMap<CartItemCreateDto, CartItem>();
		CreateMap<CartItem, CartItemDetailDto>().ForMember(c => c.ProductName, op => op.MapFrom(c => c.Product.Name))
			.ForMember(c => c.Price, op => op.MapFrom(c => c.Product.Price));
	}
}
