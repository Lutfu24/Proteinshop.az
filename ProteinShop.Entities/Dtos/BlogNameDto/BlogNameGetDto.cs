using Core.Entities.Abstract;
using ProteinShop.Entities.Dtos.BlogDto;

namespace ProteinShop.Entities.Dtos.BlogNameDto;

public class BlogNameGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<BlogGetDto> Blogs { get; set; }
}
