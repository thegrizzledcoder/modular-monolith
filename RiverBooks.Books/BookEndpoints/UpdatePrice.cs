using FastEndpoints;
using RiverBooks.Books.Application;
using RiverBooks.Books.Domain;

namespace RiverBooks.Books.BookEndpoints;

internal class UpdatePrice(IBookService bookService) :
  Endpoint<UpdateBookPriceRequest, BookDto>
{
  public override void Configure()
  {
    Patch("/books/{id}/priceHistory");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateBookPriceRequest request,
    // ReSharper disable once OptionalParameterHierarchyMismatch
    CancellationToken cancellationToken = default)
  {
    // TODO: Handle not found
    await bookService.UpdateBookPrice(new BookId(request.Id), request.NewPrice);

    var updatedBook = await bookService.GetBookById(new BookId(request.Id));

    await SendAsync(updatedBook!, cancellation: cancellationToken);
  }
}
