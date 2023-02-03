using FluentValidation;
using StarWars.Contracts.Requests;

namespace StarWars.Api.Validation;

public class SearchPlanetsValidator : Validator<SearchPlanetsRequest>
{
    public SearchPlanetsValidator()
    {
        RuleFor(x => x.Search)
            .NotEmpty()
            .WithMessage("The search query is required.")
            .MinimumLength(3)
            .WithMessage("The search query is too short. Use 3 characters or greater.");
    }
}