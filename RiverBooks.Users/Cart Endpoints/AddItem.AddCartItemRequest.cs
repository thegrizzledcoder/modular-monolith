namespace RiverBooks.Users.Cart_Endpoints;

public record AddCartItemRequest(Guid BookId, int Quantity);
