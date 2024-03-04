using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace RiverBooks.Users.Data;

public class CartItem
{
  public CartItem(Guid bookId, string description, int quantity, decimal unitPrice)
  {
    Id = new CartItemId(Guid.NewGuid());
    BookId = Guard.Against.Default(bookId);
    Description = Guard.Against.NullOrEmpty(description);
    Quantity = Guard.Against.Negative(quantity);
    UnitPrice = Guard.Against.Negative(unitPrice);
  }

  public CartItemId Id { get; private set; }
  public Guid BookId { get; private set; }
  
  [MaxLength(1000)]
  public string Description { get; private set; }
  public int Quantity { get; private set; }
  public decimal UnitPrice { get; private set; }

  internal void UpdateQuantity(int quantity)
  {
    Quantity = Guard.Against.Negative(quantity);
  }

  public void UpdateDescription(string itemDescription)
  {
    Description = Guard.Against.NullOrEmpty(itemDescription);
  }

  public void UpdatePrice(decimal itemUnitPrice)
  {
    UnitPrice = Guard.Against.Negative(itemUnitPrice);
  }
}
