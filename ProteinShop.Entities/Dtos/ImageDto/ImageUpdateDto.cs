using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.ImageDto;

public class ImageUpdateDto : IDto
{
    public int Id { get; set; }
    public string Path { get; set; }
    public int ProductId { get; set; }
}
