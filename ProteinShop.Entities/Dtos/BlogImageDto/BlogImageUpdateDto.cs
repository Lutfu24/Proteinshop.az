using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BlogImageDto;

public class BlogImageUpdateDto : IDto
{
    public int Id { get; set; }
    public string Path { get; set; }
    public int BlogId { get; set; }
}
