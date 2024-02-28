using Ardalis.Result;
using MediatR;
using RiverBooks.Books.Domain;

namespace RiverBooks.Users.UseCases;

public record AddItemToCartCommand(BookId BookId, int Quantity, string EmailAddress) 
  : IRequest<Result>;
