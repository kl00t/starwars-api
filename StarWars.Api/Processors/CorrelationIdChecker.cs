using FluentValidation.Results;

namespace StarWars.Api.Processors;

public class CorrelationIdChecker<TRequest> : IPreProcessor<TRequest>
{
    public Task PreProcessAsync(TRequest req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        var correlationId = ctx.Request.Headers["x-correlation-id"].FirstOrDefault();

        if (correlationId == null)
        {
            failures.Add(new("MissingHeaders", "The [x-correlation-id] header needs to be set!"));
            return ctx.Response.SendErrorsAsync(failures); //sending response here
        }

        if (correlationId != "qwerty")
            return ctx.Response.SendForbiddenAsync(); //sending response here

        return Task.CompletedTask;
    }
}