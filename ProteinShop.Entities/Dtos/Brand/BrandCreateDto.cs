using Core.Utilities.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.Brand;

public class BrandCreateDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
