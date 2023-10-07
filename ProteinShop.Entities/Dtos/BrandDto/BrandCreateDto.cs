using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BrandDto;

public class BrandCreateDto : IDto
{
    public string BrandName { get; set; }
}
