namespace RiverBooks.Books;

public class ListBooksResponse(List<BookDto> books)
{
  public List<BookDto> Books { get; init; } = books;
}
