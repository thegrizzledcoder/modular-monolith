﻿using Ardalis.Result;
using MediatR;
using RiverBooks.Users.Application;

namespace RiverBooks.Users.UseCases;

public record ListCartItemsQuery(string EmailAddress) : IRequest<Result<List<CartItemDto>>>;

internal class ListCartItemsQueryHandler : IRequestHandler<ListCartItemsQuery,
  Result<List<CartItemDto>>>
{
  private readonly IApplicationUserRepository _userRepository;

  public ListCartItemsQueryHandler(IApplicationUserRepository userRepository)
  {
    _userRepository = userRepository;
  }
  
  public async Task<Result<List<CartItemDto>>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetUserWithCartByEmail(request.EmailAddress);

    if (user is null)
    {
      return Result.Unauthorized();
    }

    return user.CartItems
      .Select(item =>
        new CartItemDto(item.Id.Value, item.BookId, item.Description, item.Quantity, item.UnitPrice))
      .ToList();
  }
}
