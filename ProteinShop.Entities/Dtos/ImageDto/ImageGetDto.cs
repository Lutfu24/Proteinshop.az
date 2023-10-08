using Core.Entities.Abstract;
using ProteinShop.Entities.Dtos.ProductDto;

namespace ProteinShop.Entities.Dtos.ImageDto;

public class ImageGetDto:IDto
{
    public int Id { get; set; }
    public string Path { get; set; }
    public int ProductId { get; set; }
}
