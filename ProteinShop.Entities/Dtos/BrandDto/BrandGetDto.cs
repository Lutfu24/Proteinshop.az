using Core.Entities.Abstract;
using ProteinShop.Entities.Dtos.BrandImageDto;
using ProteinShop.Entities.Dtos.ProductDto;

namespace ProteinShop.Entities.Dtos.BrandDto;

public class BrandGetDto:IDto
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public List<ProductGetDto>? Products { get; set; }
    public List<BrandImageGetDto> BrandImages { get; set; }
}
