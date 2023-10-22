﻿using AutoMapper;
using Core.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            var accessToken = await _authService.CreateTokenAsync(result.Data);
            return Ok(new {accessToken,result.Data.UserName});
        }
        [HttpGet("GetUser")]
        [Authorize]
        public async Task<IActionResult> GetUser(string userName)
        {
            var result = await _authService.GetUserAsync(userName);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
