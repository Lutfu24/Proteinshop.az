using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.BlogNameDto;

public class BlogNameCreateDto : IDto
{
    public string Name { get; set; }
}
