using Core.Utilities.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.Product;

public class ProductUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public double Raiting { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public bool IsAvailability { get; set; }
    public bool IsFavorite { get; set; }
    public int BrandId { get; set; }
}
