using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookService(this IServiceCollection services)
    {
        return services.AddScoped<IBookService, BookService>();
    }
}