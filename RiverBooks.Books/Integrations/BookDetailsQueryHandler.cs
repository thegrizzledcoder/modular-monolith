using Ardalis.Result;
using MediatR;
using RiverBooks.Books.Application;
using RiverBooks.Books.Contracts.Contracts;
using RiverBooks.Books.Domain;

namespace RiverBooks.Books.Integrations;

internal class BookDetailsQueryHandler :
  IRequestHandler<BookDetailsQuery, Result<BookDetailResponse>>
{
  private readonly IBookService _bookService;

  public BookDetailsQueryHandler(IBookService bookService)
  {
    _bookService = bookService;
  }
  public async Task<Result<BookDetailResponse>> Handle(BookDetailsQuery request, CancellationToken cancellationToken)
  {
    var book = await _bookService.GetBookById(new BookId(request.BookId));
    if (book is null)
    {
      return Result.NotFound();
    }
    
    var response = new BookDetailResponse(book.Id, book.Title, book.Author, book.Price);

    return response;
  }
}
