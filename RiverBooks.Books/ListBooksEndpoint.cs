using FastEndpoints;

namespace RiverBooks.Books;

// https://fast-endpoints.com

internal class ListBooksEndpoint(IBookService bookService) :
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
        var books = bookService.ListBooks();
        await SendAsync(new ListBooksResponse(books), cancellation: cancellationToken);
    }
}
