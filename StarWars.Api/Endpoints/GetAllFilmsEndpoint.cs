using StarWars.Contracts.Responses;
using StarWars.Mapping;
using StarWars.Services;

namespace StarWars.Api.Endpoints;

public class GetAllFilmsEndpoint : EndpointWithoutRequest<GetAllFilmsResponse>
{
    private readonly IStarWarsService _starWarsService;

    public GetAllFilmsEndpoint(IStarWarsService starWarsService)
    {
        _starWarsService = starWarsService;
    }

    public override void Configure()
    {
        Get("film");
        ResponseCache(60);
        Permissions(Domain.Constants.Permissions.GetFilmPermission);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var films = await _starWarsService.GetAllFilms();
        var response = films.ToGetAllFilmsResponse();
        await SendAsync(response, cancellation: ct);
    }
}