using Core.Entities.Abstract;
using ProteinShop.Entities.Dtos.BlogImageDto;
using ProteinShop.Entities.Dtos.BlogNameDto;

namespace ProteinShop.Entities.Dtos.BlogDto;

public class BlogGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int BlogNameId { get; set; }
    public BlogNameGetDto BlogName { get; set; }
    public List<BlogImageGetDto> BlogImages { get; set; }
}
