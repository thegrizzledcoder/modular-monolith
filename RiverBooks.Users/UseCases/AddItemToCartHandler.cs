using Ardalis.Result;
using MediatR;
using RiverBooks.Books.Contracts;
using RiverBooks.Books.Contracts.Contracts;
using RiverBooks.Users.Data;

namespace RiverBooks.Users.UseCases;

public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, Result>
{
  private readonly IMediator _mediator;
  private readonly IApplicationUserRepository _userRepository;

  public AddItemToCartHandler(IApplicationUserRepository userRepository, IMediator mediator)
  {
    _userRepository = userRepository;
    _mediator = mediator;
  }

  public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetUserWithCartByEmail(request.EmailAddress);

    if (user is null) { return Result.Unauthorized(); }

    var query = new BookDetailsQuery(request.BookId);
    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      return Result.NotFound();
    }

    var bookDetails = result.Value;
    string description = $"{bookDetails.Title} by {bookDetails.Author}";
    var newCartItem = new CartItem(request.BookId, description,
      request.Quantity, bookDetails.Price);

    user.AddItemToCart(newCartItem);

    await _userRepository.SaveChanges();
    return Result.Success();
  }
}
