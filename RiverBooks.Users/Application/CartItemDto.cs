namespace RiverBooks.Users.Application;

public record CartItemDto(Guid Id, Guid BookId, string Description,
  int Quantity, decimal UnitePrice);
