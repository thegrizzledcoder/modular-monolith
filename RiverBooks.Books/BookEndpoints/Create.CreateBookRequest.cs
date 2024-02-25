namespace RiverBooks.Books.BookEndpoints;

public class CreateBookRequest
{
  public Guid? Id { get; set; }
  public string Title { get; set; } = String.Empty;
  public string Author { get; set; } = String.Empty;
  public decimal Price { get; set; }
}
