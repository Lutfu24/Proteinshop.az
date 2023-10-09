using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.CartItemDto;

public class CartItemUpdateDto : IDto
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
}
