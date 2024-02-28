using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Books.Data;
using Serilog;

namespace RiverBooks.Books.Application;

public static class BookServiceExtensions
{
  public static IServiceCollection AddBookService(this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger, List<Assembly> mediatRAssemblies)
  {
    var connectionString = config.GetConnectionString("BooksConnectionString");
    services.AddDbContext<BookDbContext>(options => options.UseSqlServer(connectionString));
    services.AddScoped<IBookRepository, EfBookRepository>();
    services.AddScoped<IBookService, BookService>();

    mediatRAssemblies.Add(typeof(BookServiceExtensions).Assembly);
    
    logger.Information("{Module} module services registered", "Books");
    
    return services;
  }
}
