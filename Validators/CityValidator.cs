using FluentValidation;
using Countries.Models;

public class CityValidator : AbstractValidator<City>
{
    public CityValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("City name is required.");
        RuleFor(c => c.CountryId).GreaterThan(0).WithMessage("Valid country ID is required.");
    }
}