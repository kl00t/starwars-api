using StarWars.Api.Processors;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;
using StarWars.Mapping;
using StarWars.Services;

namespace StarWars.Api.Endpoints;

public class SearchFilmsEndpoint : Endpoint<SearchFilmsRequest, SearchFilmsResponse>
{
    private readonly IStarWarsService _starWarsService;

    public SearchFilmsEndpoint(IStarWarsService starWarsService)
    {
        _starWarsService = starWarsService;
    }

    public override void Configure()
    {
        Get("film/{search}");
        Permissions(Domain.Constants.Permissions.GetFilmPermission);
        ////PreProcessors(new CorrelationIdChecker<SearchFilmsRequest>());
        PreProcessors(new RequestLogger<SearchFilmsRequest>());
        PostProcessors(new ResponseLogger<SearchFilmsRequest, SearchFilmsResponse>());
    }

    public override async Task HandleAsync(SearchFilmsRequest req, CancellationToken ct)
    {
        var film = await _starWarsService.SearchFilm(req.Search);
        var response = film.ToSearchFilmsResponse();
        await SendAsync(response, cancellation: ct);
    }
}