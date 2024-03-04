namespace RiverBooks.Books.Contracts.Contracts;

public record BookDetailResponse(Guid BookId, string Title, string Author, decimal Price);
