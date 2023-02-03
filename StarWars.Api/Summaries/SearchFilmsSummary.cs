using StarWars.Api.Endpoints;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;

namespace StarWars.Api.Summaries;

public class SearchFilmsSummary : Summary<SearchFilmsEndpoint>
{
    private readonly SearchFilmsResponse _exampleResponse = new()
    {
        Count = 1,
        Results = new Film[]
        {
            new Film(5, "The Empire Strikes Back", "It is a dark time for the\r\nRebellion.", new Production("Irvin Kershner","Gary Kurtz, Rick McCallum", new DateTime(1980, 5, 17)))
        }
    };

    public SearchFilmsSummary()
	{
        Summary = "Search the film api endpoint.";
        Description = "Returns a SearchFilmResponse with a list of films matching the search criteria.";
        ExampleRequest = new SearchFilmsRequest { Search = "emp" };
        Response(200, "ok response with body", example: _exampleResponse);
        Response<ErrorResponse>(400, "validation failure");
        Response(404, "film not found");
        Response(401, "not authorised");
    }
}