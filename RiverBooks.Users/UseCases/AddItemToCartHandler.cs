using Ardalis.Result;
using MediatR;
using RiverBooks.Users.Data;

namespace RiverBooks.Users.UseCases;

public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, Result>
{
  private readonly IApplicationUserRepository _userRepository;

  public AddItemToCartHandler(IApplicationUserRepository userRepository)
  {
    _userRepository = userRepository;
  }
  
  public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetUserWithCartByEmail(request.EmailAddress);

    if (user is null) { return Result.Unauthorized(); }

    var newCartItem = new CartItem(request.BookId, "description",
      request.Quantity, 1.00m);
    
    user.AddItemToCart(newCartItem);
    
    await _userRepository.SaveChanges();

    return Result.Success();
  }
}
