using StarWars.Contracts.Responses;
using StarWars.Mapping;
using StarWars.Services;

namespace StarWars.Api.Endpoints;

public class GetAllPlanetsEndpoint : EndpointWithoutRequest<GetAllPlanetsResponse>
{
    private readonly IStarWarsService _starWarsService;

    public GetAllPlanetsEndpoint(IStarWarsService starWarsService)
    {
        _starWarsService = starWarsService;
    }

    public override void Configure()
    {
        Get("planet");
        ResponseCache(60);
        Permissions(Domain.Constants.Permissions.GetPlanetPermision);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var planets = await _starWarsService.GetAllPlanets();
        var response = planets.ToGetAllPlanetsResponse();
        await SendAsync(response, cancellation: ct);
    }
}