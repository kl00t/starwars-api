using StarWars.Api.Processors;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;
using StarWars.Mapping;
using StarWars.Services;

namespace StarWars.Api.Endpoints;

public class SearchPlanetsEndpoint : Endpoint<SearchPlanetsRequest, SearchPlanetsResponse>
{
    private readonly IStarWarsService _starWarsService;

    public SearchPlanetsEndpoint(IStarWarsService starWarsService)
    {
        _starWarsService = starWarsService;
    }

    public override void Configure()
    {
        Get("planet/{search}");
        Permissions(Domain.Constants.Permissions.GetPlanetPermision);
        ////PreProcessors(new CorrelationIdChecker<SearchPlanetsRequest>());
        PreProcessors(new RequestLogger<SearchPlanetsRequest>());
        PostProcessors(new ResponseLogger<SearchPlanetsRequest, SearchPlanetsResponse>());
    }

    public override async Task HandleAsync(SearchPlanetsRequest req, CancellationToken ct)
    {
        var planet = await _starWarsService.SearchPlanet(req.Search);
        var response = planet.ToSearchPlanetsResponse();
        await SendAsync(response, cancellation: ct);
    }
}