using System.Runtime.InteropServices;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users.Data;

public class ApplicationUser : IdentityUser
{
  public string FullName { get; set; } = "";
  private readonly List<CartItem> _cartItems = new();
  public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

  public void AddItemToCart(CartItem item)
  {
    Guard.Against.Null(item);

    var existingBook = _cartItems.SingleOrDefault(c => c.BookId == item.BookId);
    if (existingBook != null)
    {
      existingBook.UpdateQuantity(existingBook.Quantity + item.Quantity);
      // TODO: What to do if other details of the item have been updated?
      return;
    }
    _cartItems.Add(item);
  }
}

public record struct CartItemId(Guid Value);
