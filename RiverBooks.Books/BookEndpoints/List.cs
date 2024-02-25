using FastEndpoints;
using RiverBooks.Books.Application;

namespace RiverBooks.Books.BookEndpoints;

// https://fast-endpoints.com

internal class List(IBookService bookService) :
  EndpointWithoutRequest<ListBooksResponse>
{
  public override void Configure()
  {
    Get("/books");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    // ReSharper disable once OptionalParameterHierarchyMismatch
    CancellationToken cancellationToken = default)
  {
    var books = await bookService.ListBooks();
    await SendAsync(new ListBooksResponse(books), cancellation: cancellationToken);
  }
}
