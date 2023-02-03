using StarWars.Api.Endpoints;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;

namespace StarWars.Api.Summaries;

public class SearchPlanetsSummary : Summary<SearchPlanetsEndpoint>
{
    private readonly SearchPlanetsResponse _exampleResponse = new()
    {
        Count = 1,
        Results = new Planet[]
        {
            new Planet(
                name: "Alderaan",
                diameter: "12500",
                gravity: "364",
                orbitalPeriod: "364",
                population: "2000000000",
                rotationPeriod: "24",
                geography: new Geography(
                    terrain: "grasslands, mountains",
                    surfaceWater: "40",
                    climate: "temperate"))
        }
    };

    public SearchPlanetsSummary()
	{
        Summary = "Search the plant api endpoint.";
        Description = "Returns a SearchPlanetsResponse with a list of planets matching the search criteria.";
        ExampleRequest = new SearchPlanetsRequest { Search = "ald" };
        Response(200, "ok response with body", example: _exampleResponse);
        Response<ErrorResponse>(400, "validation failure");
        Response(404, "planet not found");
        Response(401, "not authorised");
    }
}
