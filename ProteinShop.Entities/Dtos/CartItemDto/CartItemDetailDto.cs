using Core.Entities.Abstract;

namespace ProteinShop.Entities.Dtos.CartItemDto;

public class CartItemDetailDto:IDto
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
    public string AppUserId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public bool IsDeleted { get; set; }
}
