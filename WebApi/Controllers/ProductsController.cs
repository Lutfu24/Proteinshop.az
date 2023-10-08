using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;
using ProteinShop.Entities.Dtos.ProductDto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetFilterBest")]
        public async Task<IActionResult> GetFilterBest(bool isBestSeller)
        {
            var result = await _productService.GetFilterBest(isBestSeller);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetFilterNew")]
        public async Task<IActionResult> GetFilterNew(bool isNew)
        {
            var result = await _productService.GetFilterNew(isNew);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetFilterDiscount")]
        public async Task<IActionResult> GetFilterDiscount()
        {
            var result = await _productService.GetFilterDiscount();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProductCreateDto productCreateDto)
        {
            var result = await _productService.AddAsync(productCreateDto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
