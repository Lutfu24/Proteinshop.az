using Core.Utilities.Results.Abstract;
using ProteinShop.Entities.Dtos.CartItemDto;

namespace ProteinShop.Business.Abstract;

public interface ICartItemService
{
    Task<IDataResult<List<CartItemDetailDto>>> GetAllAsync();
    Task<IDataResult<CartItemDetailDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(CartItemCreateDto cartItemCreateDto);
    Task<IResult> UpdateAsync(CartItemUpdateDto cartItemUpdateDto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IResult> DeleteAsync(CartItemDetailDto dto);
}
