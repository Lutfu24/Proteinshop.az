using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;
using ProteinShop.Entities.Dtos.BlogImageDto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogImagesController : ControllerBase
    {
        private readonly IBlogImageService _imageService;

        public BlogImagesController(IBlogImageService imageService)
        {
            _imageService = imageService;
        }

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
        public async Task<IActionResult> Add(BlogImageCreateDto blogImageCreateDto)
        {
            var result = await _imageService.AddAsync(blogImageCreateDto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
