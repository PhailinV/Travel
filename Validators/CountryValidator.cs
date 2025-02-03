using FluentValidation;
using Countries.Models;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Country name is required.");
        RuleFor(c => c.Continent).NotEmpty().WithMessage("Continent is required.");
        RuleFor(c => c.Budget).GreaterThan(0).WithMessage("Budget must be greater than zero.");
    }
}