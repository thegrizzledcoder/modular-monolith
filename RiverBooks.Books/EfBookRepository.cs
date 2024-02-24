using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books;

internal class EfBookRepository : IBookRepository
{
  private readonly BookDbContext _dbContext;

  public EfBookRepository(BookDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task<Book?> GetById(BookId id)
  {
    return await _dbContext!.Books.FindAsync(id.Value);
  }

  public async Task<List<Book>> List()
  {
    return await _dbContext.Books!.ToListAsync();
  }

  public Task Add(Book book)
  {
    _dbContext.Books.Add(book);
    return Task.CompletedTask;
  }

  public Task Delete(Book book)
  {
    _dbContext.Books.Remove(book);
    return Task.CompletedTask;
  }

  public async Task SaveChanges()
  {
    await _dbContext.SaveChangesAsync();
  }
}
