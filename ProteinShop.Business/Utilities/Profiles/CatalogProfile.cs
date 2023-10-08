using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.CatalogDto;

namespace ProteinShop.Business.Utilities.Profiles;

public class CatalogProfile : Profile
{
    public CatalogProfile()
    {
        CreateMap<Catalog, CatalogGetDto>();
        CreateMap<CatalogCreateDto, Catalog>();
        CreateMap<CatalogUpdateDto, Catalog>();
    }
}
