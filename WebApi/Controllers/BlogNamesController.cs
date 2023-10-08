using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;
using ProteinShop.Entities.Dtos.BlogNameDto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogNamesController : ControllerBase
    {
        private readonly IBlogNameService _blogNameService;

        public BlogNamesController(IBlogNameService blogNameService)
        {
            _blogNameService = blogNameService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _blogNameService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _blogNameService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(BlogNameCreateDto blogNameCreateDto)
        {
            var result = await _blogNameService.AddAsync(blogNameCreateDto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
