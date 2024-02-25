using RiverBooks.Books.Domain;

namespace RiverBooks.Books.Data;

internal interface IBookRepository : IReadOnlyBookRepository
{
  Task Add(Book book);
  Task Delete(Book book);
  Task SaveChanges();
}
