﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RiverBooks.Books.Domain;

namespace RiverBooks.Books.Data;

public class BookDbContext : DbContext
{
  public DbSet<Book> Books { get; set; } = null!;

  public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("Books");
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.Properties<decimal>()
      .HavePrecision(18, 6);
  }
}
