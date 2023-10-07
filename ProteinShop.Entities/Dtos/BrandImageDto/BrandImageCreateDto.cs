using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BrandImageDto;

public class BrandImageCreateDto : IDto
{
    public string Path { get; set; }
    public int BrandId { get; set; }
}
