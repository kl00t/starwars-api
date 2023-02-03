using StarWars.Api.Events;
using StarWars.Api.Processors;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;
using StarWars.Mapping;
using StarWars.Services;

namespace StarWars.Api.Endpoints;

public class CreateFilmEndpoint : Endpoint<CreateFilmRequest, CreateFilmResponse>
{
    private readonly IStarWarsService _starWarsService;

    public CreateFilmEndpoint(IStarWarsService starWarsService)
    {
        _starWarsService = starWarsService;
    }

    public override void Configure()
    {
        Post("film");
        Permissions(Domain.Constants.Permissions.CreateFilmPermission);
        PreProcessors(new RequestLogger<CreateFilmRequest>());
        PostProcessors(new ResponseLogger<CreateFilmRequest, CreateFilmResponse>());
    }

    public override async Task HandleAsync(CreateFilmRequest req, CancellationToken ct)
    {
        var film = req.ToDomain();
        var createdFilm = await _starWarsService.CreateFilm(film);

        await PublishAsync(new CreateFilmEvent
        {
            EpisodeId = createdFilm.EpisodeId,
            Title = createdFilm.Title
        }, Mode.WaitForNone, ct);

        var response = createdFilm.ToCreateFilmResponse();
        await SendAsync(response, cancellation: ct);
    }
}