using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BlogImageDto;

public class BlogImageCreateDto : IDto
{
    public string Path { get; set; }
    public int BlogId { get; set; }
}
