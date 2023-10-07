using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BlogNameDto;

public class BlogNameUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
