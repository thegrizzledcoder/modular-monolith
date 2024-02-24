namespace RiverBooks.Books;

internal interface IReadOnlyBookRepository
{
  Task<Book?> GetById(BookId id);
  Task<List<Book>> List();
}
