using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.BookEndpoints;

public class CreateBookRequest
{
  public Guid? Id { get; set; }
  public string Title { get; set; } = String.Empty;
  public string Author { get; set; } = String.Empty;
  public decimal Price { get; set; }
}

public class CreateBookRequestValidator : Validator<CreateBookRequest>
{
  public CreateBookRequestValidator()
  {
    RuleFor(x => x.Title)
      .NotNull()
      .NotEmpty()
      .WithMessage("A book title is required.");

    RuleFor(x => x.Title)
      .MaximumLength(100)
      .WithMessage("Book titles may not exceed 100 characters.");
    
    RuleFor(x => x.Author)
      .NotNull()
      .NotEmpty()
      .WithMessage("A book author is required.");
    
    RuleFor(x => x.Author)
      .MaximumLength(100)
      .WithMessage("Book authors may not exceed 100 characters.");

    RuleFor(x => x.Price)
      .GreaterThanOrEqualTo(0)
      .WithMessage("Book prices may not be negative.");
  }
}
