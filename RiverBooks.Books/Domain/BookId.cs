namespace RiverBooks.Books.Domain;

public readonly record struct BookId(Guid Value)
{
  public static BookId Empty => new(Guid.Empty);
  public static BookId NewBookId() => new(Guid.NewGuid());
  public static BookId From(Guid id) => new(id);
}