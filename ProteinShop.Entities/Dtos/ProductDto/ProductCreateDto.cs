using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.ProductDto;

public class ProductCreateDto : IDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double Raiting { get; set; }
    public string Description { get; set; }
    public bool IsAvailability { get; set; }
    public int? BrandId { get; set; }
    public int CatalogId { get; set; }
}