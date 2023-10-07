using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BrandImageDto;

public class BrandImageUpdateDto : IDto
{
    public int Id { get; set; }
    public string Path { get; set; }
    public int BrandId { get; set; }
}
