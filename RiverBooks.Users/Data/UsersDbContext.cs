using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RiverBooks.Users.Data;

public class UsersDbContext : IdentityDbContext<ApplicationUser>
{
  public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
  {
  }

  public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
  public DbSet<CartItem> CartItems { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.HasDefaultSchema("Users");

    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    base.OnModelCreating(builder);
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.Properties<decimal>()
      .HavePrecision(18, 6);
  }
}
