using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BrandDto;

public class BrandUpdateDto : IDto
{
    public int Id { get; set; }
    public string BrandName { get; set; }
}
