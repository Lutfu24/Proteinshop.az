using Core.Entities.Abstract;
using ProteinShop.Entities.Dtos.BlogDto;

namespace ProteinShop.Entities.Dtos.BlogImageDto;

public class BlogImageGetDto:IDto
{
    public int Id { get; set; }
    public string Path { get; set; }
    public int BlogId { get; set; }
    public BlogGetDto Blog { get; set; }
}
