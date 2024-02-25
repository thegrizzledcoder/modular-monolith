using FastEndpoints;
using RiverBooks.Books.Application;
using RiverBooks.Books.Domain;

namespace RiverBooks.Books.BookEndpoints;

internal class GetById(IBookService bookService) :
  Endpoint<GetBookByIdRequest, BookDto>
{
  public override void Configure()
  {
    Get("/books/{id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    GetBookByIdRequest request,
    // ReSharper disable once OptionalParameterHierarchyMismatch
    CancellationToken cancellationToken = default)
  {
    var book = await bookService.GetBookById(new BookId(request.Id));
    if (book is null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    await SendAsync(book, cancellation: cancellationToken);
  }
}
