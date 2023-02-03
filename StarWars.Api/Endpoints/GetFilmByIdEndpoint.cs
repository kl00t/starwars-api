using StarWars.Api.Processors;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;
using StarWars.Mapping;
using StarWars.Services;

namespace StarWars.Api.Endpoints;

public class GetFilmByIdEndpoint : Endpoint<GetFilmByIdRequest, GetFilmByIdResponse>
{
    private readonly IStarWarsService _starWarsService;

    public GetFilmByIdEndpoint(IStarWarsService starWarsService)
    {
        _starWarsService = starWarsService;
    }

    public override void Configure()
    {
        Get("film/{id:int}");
        Permissions(Domain.Constants.Permissions.GetFilmPermission);
        ////PreProcessors(new CorrelationIdChecker<SearchFilmsRequest>());
        PreProcessors(new RequestLogger<GetFilmByIdRequest>());
        PostProcessors(new ResponseLogger<GetFilmByIdRequest, GetFilmByIdResponse>());
    }

    public override async Task HandleAsync(GetFilmByIdRequest req, CancellationToken ct)
    {
        var films = await _starWarsService.GetFilmById(req.Id);
        var response = films.ToGetFilmByIdResponse();
        await SendAsync(response, cancellation: ct);
    }
}