using Microsoft.AspNetCore.Mvc;
using ProteinShop.Business.Abstract;
using ProteinShop.Entities.Dtos.ProductDto;

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
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
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
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(ProductDeleteDto product)
        {
            var result = await _productService.DeleteAsync(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _productService.DeleteByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            var result = await _productService.UpdateAsync(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
