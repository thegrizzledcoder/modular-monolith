using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book> {
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.Property(b => b.Id).HasConversion(b => b.Value, b => new BookId(b));
    builder.Property(b => b.Title).HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH).IsRequired();
    builder.Property(b => b.Author).HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH).IsRequired();

    builder.HasData(GetSampleBookData());
  }

  private IEnumerable<Book> GetSampleBookData()
  {
    var tolkien = "J.R.R. Tolkien";
    yield return new Book(BookId.NewBookId(), "The Hobbit", tolkien, 9.99m);
    yield return new Book(BookId.NewBookId(), "The Fellowship of the Ring", tolkien, 10.99m);
    yield return new Book(BookId.NewBookId(), "The Two Towers", tolkien, 11.99m);
    yield return new Book(BookId.NewBookId(), "The Return of the King", tolkien, 12.99m);
  }
}
