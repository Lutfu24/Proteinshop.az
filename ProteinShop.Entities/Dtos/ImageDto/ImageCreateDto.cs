using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.ImageDto;

public class ImageCreateDto : IDto
{
    public string Path { get; set; }
    public int ProductId { get; set; }
}
