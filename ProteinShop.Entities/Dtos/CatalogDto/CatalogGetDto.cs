using Core.Entities.Abstract;
using ProteinShop.Entities.Dtos.ProductDto;

namespace ProteinShop.Entities.Dtos.CatalogDto;

public class CatalogGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ProductGetDto> Products { get; set; }
}
