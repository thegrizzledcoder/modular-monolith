using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Users.Data;

internal class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
  public void Configure(EntityTypeBuilder<CartItem> builder)
  {
    builder.Property(c => c.Id)
      .HasConversion(c => c.Value, c => new CartItemId(c));

    builder.HasKey(c => c.Id)
      .IsClustered(false);
  }
}
