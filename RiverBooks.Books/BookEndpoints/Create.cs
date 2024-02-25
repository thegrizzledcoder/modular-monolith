using FastEndpoints;
using RiverBooks.Books.Application;

namespace RiverBooks.Books.BookEndpoints;

internal class Create(IBookService bookService) :
  Endpoint<CreateBookRequest, BookDto>
{
  public override void Configure()
  {
    Post("/books");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    CreateBookRequest request,
    // ReSharper disable once OptionalParameterHierarchyMismatch
    CancellationToken cancellationToken = default)
  {
    var newBookDto = new BookDto(request.Id ?? Guid.NewGuid(),
      request.Title, request.Author, request.Price);
    await bookService.CreateBook(newBookDto);
    await SendCreatedAtAsync<GetById>(new { newBookDto.Id }, newBookDto, cancellation: cancellationToken);
  }
}
