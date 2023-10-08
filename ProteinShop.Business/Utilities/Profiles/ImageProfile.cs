using AutoMapper;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.ImageDto;

namespace ProteinShop.Business.Utilities.Profiles;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<Image, ImageGetDto>();
        CreateMap<ImageCreateDto, Image>();
        CreateMap<ImageUpdateDto, Image>();
    }
}
