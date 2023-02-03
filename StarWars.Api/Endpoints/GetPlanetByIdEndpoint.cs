using StarWars.Api.Processors;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;
using StarWars.Mapping;
using StarWars.Services;

namespace StarWars.Api.Endpoints;

public class GetPlanetByIdEndpoint : Endpoint<GetPlanetByIdRequest, GetPlanetByIdResponse>
{
    private readonly IStarWarsService _starWarsService;

    public GetPlanetByIdEndpoint(IStarWarsService starWarsService)
    {
        _starWarsService = starWarsService;
    }

    public override void Configure()
    {
        Get("planet/{id:int}");
        Permissions(Domain.Constants.Permissions.GetFilmPermission);
        ////PreProcessors(new CorrelationIdChecker<SearchFilmsRequest>());
        PreProcessors(new RequestLogger<GetPlanetByIdRequest>());
        PostProcessors(new ResponseLogger<GetPlanetByIdRequest, GetPlanetByIdResponse>());
    }

    public override async Task HandleAsync(GetPlanetByIdRequest req, CancellationToken ct)
    {
        var planets = await _starWarsService.GetPlanetById(req.Id);
        var response = planets.ToGetPlanetByIdResponse();
        await SendAsync(response, cancellation: ct);
    }
}