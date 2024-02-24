namespace RiverBooks.Books;

internal interface IBookService
{
    Task<List<BookDto>> ListBooks();
    Task<BookDto> GetBookById(BookId bookId);
    Task CreateBook(BookDto newBook);
    Task DeleteBook(BookId bookId);
    Task UpdateBookPrice(BookId bookId, decimal newPrice);
}
