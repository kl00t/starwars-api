using FluentValidation.Results;

namespace StarWars.Api.Processors;

public class RequestLogger<TRequest> : IPreProcessor<TRequest>
{
    public Task PreProcessAsync(TRequest req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        var logger = ctx.Resolve<ILogger<TRequest>>();

        logger.LogInformation($"request:{req?.GetType().FullName} path: {ctx.Request.Path}");

        return Task.CompletedTask;
    }
}