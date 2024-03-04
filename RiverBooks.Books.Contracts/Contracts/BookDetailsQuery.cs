using Ardalis.Result;
using MediatR;

namespace RiverBooks.Books.Contracts.Contracts;

public record BookDetailsQuery(Guid BookId) : IRequest<Result<BookDetailResponse>>;
