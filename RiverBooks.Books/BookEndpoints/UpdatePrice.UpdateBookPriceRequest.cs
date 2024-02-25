using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.BookEndpoints;

public record UpdateBookPriceRequest(Guid Id, decimal NewPrice);

public class UpdatePriceRequestValidator : Validator<UpdateBookPriceRequest>
{
  public UpdatePriceRequestValidator()
  {
    RuleFor(x => x.Id)
      .NotNull()
      .NotEqual(Guid.Empty)
      .WithMessage("A book id is required.");

    RuleFor(x => x.NewPrice)
      .GreaterThanOrEqualTo(0)
      .WithMessage("Book prices may not be negative.");
  }
}
