using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("/books", (IBookService bookService) =>
        {
            return bookService.ListBooks();
        });
    }
}

internal interface IBookService
{
    IEnumerable<BookDto> ListBooks();
}

public readonly record struct BookId(Guid Value)
{
    public static BookId Empty => new(Guid.Empty);
    public static BookId NewBookId() => new(Guid.NewGuid());
}

public record BookDto(BookId Id, string Title, string Author);

internal class BookService : IBookService
{
    public IEnumerable<BookDto> ListBooks()
    {
        return
        [
            new BookDto(BookId.NewBookId(), "The Fellowship of the Ring", "J.R.R. Tolkien"),
            new BookDto(BookId.NewBookId(), "The Two Towers", "J.R.R. Tolkien"),
            new BookDto(BookId.NewBookId(), "The Return of the King", "J.R.R. Tolkien"),
        ];
    }
}

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookService(this IServiceCollection services)
    {
        return services.AddScoped<IBookService, BookService>();
    }
}