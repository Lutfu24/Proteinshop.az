﻿using Core.Entities.Concrete.Auth;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;

namespace ProteinShop.Business.Abstract;

public interface IAuthService
{
    Task<IDataResult<AppUser>> RegisterAsync(RegisterDto registerDto);
    Task<IDataResult<AppUser>> LoginAsync(LoginDto loginDto);
    Task<IDataResult<AccessToken>> CreateTokenAsync(AppUser appUser);
    Task<IDataResult<UserDto>> GetUserAsync(string userName);
}
