using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.CartItemDto;

public class CartItemCreateDto : IDto
{
    public int Count { get; set; }
    public int ProductId { get; set; }
}
