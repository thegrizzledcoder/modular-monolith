namespace RiverBooks.Books;

internal class BookService : IBookService
{
    public List<BookDto> ListBooks()
    {
        return
        [
            new BookDto(BookId.NewBookId(), "The Fellowship of the Ring", "J.R.R. Tolkien"),
            new BookDto(BookId.NewBookId(), "The Two Towers", "J.R.R. Tolkien"),
            new BookDto(BookId.NewBookId(), "The Return of the King", "J.R.R. Tolkien"),
        ];
    }
}