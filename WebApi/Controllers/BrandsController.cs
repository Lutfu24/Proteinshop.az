using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Dtos.BrandDto;
using ProteinShop.Entities.Dtos.ProductDto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _brandService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("Add")]
        public async Task<IActionResult> Add(BrandCreateDto brandCreateDto)
        {
            var result = await _brandService.AddAsync(brandCreateDto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
