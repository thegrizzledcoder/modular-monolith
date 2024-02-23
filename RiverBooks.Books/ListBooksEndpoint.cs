using FastEndpoints;
using Microsoft.AspNetCore.Builder;

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
        CancellationToken cancellationToken = default)
    {
        var books = bookService.ListBooks();
        await SendAsync(new ListBooksResponse()
        {
            Books = books
        });
    }
}