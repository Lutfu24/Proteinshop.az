using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.CatalogDto;

public class CatalogCreateDto : IDto
{
    public string Name { get; set; }
}
