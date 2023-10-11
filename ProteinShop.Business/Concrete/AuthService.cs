using AutoMapper;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProteinShop.Business.Abstract;
using System.Security.Claims;

namespace ProteinShop.Business.Concrete;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenHelper _tokenHelper;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthService(UserManager<AppUser> userManager, ITokenHelper tokenHelper, IMapper mapper, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _tokenHelper = tokenHelper;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
    }

    public async Task<IDataResult<AccessToken>> CreateTokenAsync(AppUser appUser)
    {
        IList<Claim> claims = await _userManager.GetClaimsAsync(appUser);
        AccessToken accessToken = _tokenHelper.CreateToken(claims.ToList());
        return new SuccessDataResult<AccessToken>(accessToken, "Login successfully");
    }

    public async Task<IDataResult<AppUser>> LoginAsync(LoginDto loginDto)
    {
        AppUser appUser = await _userManager.FindByNameAsync(loginDto.UserName);
        if (appUser is null) return new ErrorDataResult<AppUser>("User does not exist");
        bool checkPassword = await _userManager.CheckPasswordAsync(appUser, loginDto.Password);
        if (!checkPassword)
        {
            return new ErrorDataResult<AppUser>("Username or password is wrong!");
        }
        return new SuccessDataResult<AppUser>(appUser,true);
    }

    public async Task<IDataResult<AppUser>> RegisterAsync(RegisterDto registerDto)
    {
        AppUser appUser = await _userManager.FindByNameAsync(registerDto.UserName);
        if (appUser != null) return new ErrorDataResult<AppUser>("User already exists");
        AppUser newUser = _mapper.Map<AppUser>(registerDto);
        IdentityResult result = await _userManager.CreateAsync(newUser, registerDto.Password);
        if (!result.Succeeded)
        {
            List<string> errors = new();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return new ErrorDataResult<AppUser>(string.Join(',', errors));
        }

        List<Claim> claims = AddUserClaimsAsync(newUser);

        await _userManager.AddClaimsAsync(newUser, claims);

        return new SuccessDataResult<AppUser>(newUser, "Registered successfully");
    }

    private static List<Claim> AddUserClaimsAsync(AppUser newUser)
    {
        return new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,newUser.Id),
            new Claim(ClaimTypes.Name,newUser.UserName),
            new Claim(ClaimTypes.Email,newUser.Email),
            new Claim("FullName",newUser.FullName)
        };
    }

    public async Task<IDataResult<AppUser>> GetUserAsync(string userName)
    {
        bool isAuthenticated = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        AppUser appUser = null;
        if (isAuthenticated)
        {
            appUser = _userManager.Users.FirstOrDefault(u => u.UserName == userName);
            if (appUser is null) return null;
        }

        return new SuccessDataResult<AppUser>(appUser,true);
    }
}
