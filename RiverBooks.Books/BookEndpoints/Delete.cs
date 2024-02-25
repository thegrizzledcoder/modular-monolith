using FastEndpoints;
using RiverBooks.Books.Application;

namespace RiverBooks.Books.BookEndpoints;

internal class Delete(IBookService bookService) :
  Endpoint<DeleteBookRequest>
{
  public override void Configure()
  {
    Delete("/books/{id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteBookRequest request,
    // ReSharper disable once OptionalParameterHierarchyMismatch
    CancellationToken cancellationToken = default)
  {
    // TODO: handle not found
    await bookService.DeleteBook(new BookId(request.Id));
    await SendNoContentAsync(cancellation: cancellationToken);
  }
}
