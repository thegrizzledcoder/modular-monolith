﻿using Ardalis.GuardClauses;

namespace RiverBooks.Books.Domain;

public class Book
{
  public BookId Id { get; private set; }
  public string Title { get; private set; }
  public string Author { get; private set; }
  public decimal Price { get; private set; }
  
  internal Book(BookId id, string title, string author, decimal price)
  {
    Id = Guard.Against.Default(id);
    Title = Guard.Against.NullOrEmpty(title);
    Author = Guard.Against.NullOrEmpty(author);
    Price = Guard.Against.Negative(price);
  }
  
  internal void UpdatePrice(decimal price)
  {
    Price = Guard.Against.Negative(price);
  }
}
