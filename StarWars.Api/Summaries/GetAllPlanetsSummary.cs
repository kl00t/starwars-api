using StarWars.Api.Endpoints;
using StarWars.Contracts.Responses;

namespace StarWars.Api.Summaries;

public class GetAllPlanetsSummary : Summary<GetAllPlanetsEndpoint>
{
    public GetAllPlanetsSummary()
    {
        Summary = "Gets all the planets using the planet api endpoint.";
        Description = "Returns a GetAllPlanetsResponse with a list of all planets.";
        Response<GetAllPlanetsResponse>(200, "ok response with body", example: new() {  });
        Response<ErrorResponse>(400, "validation failure");
        Response(404, "planets not found");
        Response(401, "not authorised");
    }
}