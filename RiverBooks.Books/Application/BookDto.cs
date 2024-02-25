namespace RiverBooks.Books.Application;

public readonly record struct BookId(Guid Value)
{
    public static BookId Empty => new(Guid.Empty);
    public static BookId NewBookId() => new(Guid.NewGuid());
    public static BookId From(Guid id) => new(id);
}

public record BookDto(Guid Id, string Title, string Author, decimal Price);
