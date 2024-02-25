using RiverBooks.Books.Application;

namespace RiverBooks.Books.BookEndpoints;

public class ListBooksResponse(List<BookDto> books)
{
  public List<BookDto> Books { get; init; } = books;
}
