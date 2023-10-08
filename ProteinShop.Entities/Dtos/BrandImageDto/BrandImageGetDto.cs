using Core.Entities.Abstract;
using ProteinShop.Entities.Dtos.BrandDto;

namespace ProteinShop.Entities.Dtos.BrandImageDto;

public class BrandImageGetDto:IDto
{
    public int Id { get; set; }
    public string Path { get; set; }
    public int BrandId { get; set; }
}
