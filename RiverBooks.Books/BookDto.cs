namespace RiverBooks.Books;

public readonly record struct BookId(Guid Value)
{
    public static BookId Empty => new(Guid.Empty);
    public static BookId NewBookId() => new(Guid.NewGuid());
}

public record BookDto(BookId Id, string Title, string Author);