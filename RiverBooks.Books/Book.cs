using Ardalis.GuardClauses;

namespace RiverBooks.Books;

internal interface IBookRepository : IReadOnlyBookRepository
{
  Task Add(Book book);
  Task Delete(Book book);
  Task SaveChanges();
}

internal interface IReadOnlyBookRepository
{
  Task<Book?> GetById(BookId id);
  Task<List<Book>> List();
}
internal class Book
{
  public BookId Id { get; private set; } = BookId.NewBookId();
  public string Title { get; private set; } = string.Empty;
  public string Author { get; private set; } = string.Empty;
  public decimal Price { get; private set; }
  
  internal Book(BookId id, string title, string author, decimal price)
  {
    Id = Guard.Against.Default(id);
    Title = Guard.Against.NullOrEmpty(title);
    Author = Guard.Against.NullOrEmpty(author);
    Price = Guard.Against.Negative(price);
  }
  
  internal void UpdatePrice(decimal price)
  {
    Price = Guard.Against.Negative(price);
  }
}
