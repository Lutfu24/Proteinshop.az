using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;
using ProteinShop.Entities.Dtos.ImageDto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _imageService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _imageService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ImageCreateDto imageCreateDto)
        {
            var result = await _imageService.AddAsync(imageCreateDto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
