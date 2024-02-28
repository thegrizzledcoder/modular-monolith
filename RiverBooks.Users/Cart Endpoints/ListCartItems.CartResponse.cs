using RiverBooks.Users.Application;

namespace RiverBooks.Users.Cart_Endpoints;

public class CartResponse
{
  public List<CartItemDto> CartItems { get; set; } = new();
}
