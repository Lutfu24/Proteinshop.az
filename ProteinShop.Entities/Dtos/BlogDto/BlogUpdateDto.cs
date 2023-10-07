using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BlogDto;

public class BlogUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int BlogNameId { get; set; }
}
