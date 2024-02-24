namespace RiverBooks.Books;

internal class BookService : IBookService
{
  private readonly IBookRepository _bookRepository;

  public BookService(IBookRepository bookRepository)
  {
    _bookRepository = bookRepository;
  }
    public async Task<List<BookDto>> ListBooks()
    {
      var books = (await _bookRepository.List())
        .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Price))
        .ToList();
      return books;
    }

    public async Task<BookDto> GetBookById(BookId bookId)
    {
      var book = await _bookRepository.GetById(bookId);
      // TODO: handle not found
      return new BookDto(book!.Id, book.Title, book.Author, book.Price);
    }

    public async Task CreateBook(BookDto newBook)
    {
      var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);
      
      await _bookRepository.Add(book);
      await _bookRepository.SaveChanges();
    }

    public async Task DeleteBook(BookId bookId)
    {
      var toDelete = await _bookRepository.GetById(bookId);
      if (toDelete is not null)
      {
        await _bookRepository.Delete(toDelete);
        await _bookRepository.SaveChanges();
      }
    }

    public async Task UpdateBookPrice(BookId bookId, decimal newPrice)
    {
      // validate the price
      var book = await _bookRepository.GetById(bookId);
      
      // handle not found
      book!.UpdatePrice(newPrice);
      await _bookRepository.SaveChanges();
    }
}
