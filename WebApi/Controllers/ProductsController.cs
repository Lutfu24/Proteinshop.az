using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.Product;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            if (result.Count>0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProductCreateDto productCreateDto)
        {
            await _productService.AddAsync(productCreateDto);
            return Ok();
            
        }
    }
}
