using Core.Entities.Abstract;
using ProteinShop.Entities.Concrete;

namespace ProteinShop.Entities.Dtos.Brand;

public class BrandGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
