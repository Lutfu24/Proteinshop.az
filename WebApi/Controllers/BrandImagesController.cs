using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;
using ProteinShop.Entities.Dtos.BrandImageDto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandImagesController : ControllerBase
    {
        private readonly IBrandImageService _brandImageService;

        public BrandImagesController(IBrandImageService brandImageService)
        {
            _brandImageService = brandImageService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandImageService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _brandImageService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(BrandImageCreateDto brandImageCreateDto)
        {
            var result = await _brandImageService.AddAsync(brandImageCreateDto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
