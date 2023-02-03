using StarWars.Api.Events;

namespace StarWars.Api.EventHandlers;

public class CreateFilmEventHandler : FastEventHandler<CreateFilmEvent>
{
    public override Task HandleAsync(CreateFilmEvent eventModel, CancellationToken ct)
    {
        var logger = Resolve<ILogger<CreateFilmEventHandler>>();
        logger.LogInformation($"film created created event received:[{eventModel.EpisodeId},{eventModel.Title}]");
        return Task.CompletedTask;
    }
}