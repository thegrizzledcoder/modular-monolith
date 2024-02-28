using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiverBooks.Books.Domain;

namespace RiverBooks.Users.Data;

internal class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
  public void Configure(EntityTypeBuilder<CartItem> builder)
  {
    builder.Property(c => c.Id)
      .HasConversion(c => c.Value, c => new CartItemId(c));
    builder.Property(b => b.BookId)
      .HasConversion(b => b.Value, b => new BookId(b));

    builder.HasKey(c => c.Id)
      .IsClustered(false);
  }
}
