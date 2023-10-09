using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProteinShop.Business.Abstract;
using ProteinShop.DataAccessLayer.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.CartItemDto;

namespace ProteinShop.Business.Concrete;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IProductService _productService;
    private readonly bool _isAuthenticated;
    private const string COOKIE_CART_ITEM_KEY = "mycartitemkey";

    public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper, IHttpContextAccessor contextAccessor, IProductService productService)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
        _productService = productService;
        _isAuthenticated = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public async Task<IResult> AddAsync(CartItemCreateDto cartItemCreateDto)
    {
        CartItem cartItem = _mapper.Map<CartItem>(cartItemCreateDto);
        if (_isAuthenticated)
        {
            await _cartItemRepository.AddAsync(cartItem);
        }
        else
        {
            await AddCartItemToCookie(cartItem);
        }
        return new SuccessResult(true,"Added");
    }

    public Task<IResult> DeleteAsync(CartItemDetailDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IDataResult<List<CartItemDetailDto>>> GetAllAsync()
    {
        List<CartItem> cartItems = new List<CartItem>();
        if (!_isAuthenticated)
        {
            cartItems = GetCartItemFromCookie();
            cartItems = await GetProductsToCartItem(cartItems);
        }
        else
        {
            cartItems = await _cartItemRepository.GetAllAsync(includes: new string[] { "Product" });
        }
        var result = _mapper.Map<List<CartItemDetailDto>>(cartItems);
        return new SuccessDataResult<List<CartItemDetailDto>>(result, true);
    }

    public Task<IDataResult<CartItemDetailDto>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateAsync(CartItemUpdateDto cartItemUpdateDto)
    {
        throw new NotImplementedException();
    }
    private async Task AddCartItemToCookie(CartItem cartItem)
    {
        List<CartItem> cartItems = GetCartItemFromCookie();
        if (cartItems != null)
        {
            if (cartItems.Any(c => c.ProductId == cartItem.ProductId))
            {
                cartItems.FirstOrDefault(c => c.ProductId == cartItem.ProductId).Count += cartItem.Count;
            }
            else
            {
                cartItems.Add(cartItem);
            }
        }
        else
        {
            cartItems = new List<CartItem> { cartItem };
        }
        _contextAccessor.HttpContext.Response.Cookies.Append(COOKIE_CART_ITEM_KEY, JsonConvert.SerializeObject(cartItems));
    }

    private List<CartItem> GetCartItemFromCookie()
    {
        List<CartItem> cartItems = null;
        if (_contextAccessor.HttpContext.Request.Cookies[COOKIE_CART_ITEM_KEY] != null)
        {
            cartItems = JsonConvert.DeserializeObject<List<CartItem>>(_contextAccessor.HttpContext.Request.Cookies[COOKIE_CART_ITEM_KEY]);
        }
        return cartItems;

    }
    private async Task<List<CartItem>> GetProductsToCartItem(List<CartItem> cartItems)
    {
        if (cartItems is null) return null;
        foreach (var cartItem in cartItems)
        {
           cartItem.Product = _mapper.Map<Product>((await _productService.GetByIdAsync(cartItem.ProductId)).Data);
        }
        return cartItems;
    }
}
