using FluentValidation.Results;
using StarWars.Contracts.Responses;

namespace StarWars.Api.Processors;

public class ResponseLogger<TRequest, TResponse> : IPostProcessor<TRequest, TResponse>
{
    public Task PostProcessAsync(TRequest req, TResponse res, HttpContext ctx, IReadOnlyCollection<ValidationFailure> failures, CancellationToken ct)
    {
        var logger = ctx.Resolve<ILogger<TResponse>>();

        if (res is SearchFilmsResponse searchFilmsResponse)
        {
            logger.LogInformation($"SearchFilmsResponse returned {searchFilmsResponse.Count} results.");
        }

        if (res is SearchPlanetsResponse searchPlanetsResponse)
        {
            logger.LogInformation($"SearchPlanetsResponse returned {searchPlanetsResponse.Count} results.");
        }

        return Task.CompletedTask;
    }
}