using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.CatalogDto;

public class CatalogUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
