using RiverBooks.Books.Application;
using RiverBooks.Books.Domain;

namespace RiverBooks.Books.Data;

internal interface IReadOnlyBookRepository
{
  Task<Book?> GetById(BookId id);
  Task<List<Book>> List();
}
