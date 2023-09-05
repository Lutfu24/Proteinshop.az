using AutoMapper;
using Core.Entities.Concrete.Auth;

namespace ProteinShop.Business.Utilities.Profiles;

public class AuthProfile:Profile
{
	public AuthProfile()
	{
		CreateMap<RegisterDto, AppUser>();
	}
}
