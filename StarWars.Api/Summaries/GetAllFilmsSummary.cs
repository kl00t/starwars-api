using StarWars.Api.Endpoints;
using StarWars.Contracts.Responses;

namespace StarWars.Api.Summaries;

public class GetAllFilmsSummary : Summary<GetAllFilmsEndpoint>
{
    public GetAllFilmsSummary()
    {
        Summary = "Gets all the films using the film api endpoint.";
        Description = "Returns a GetAllFilmsResponse with a list of all films.";
        Response<GetAllFilmsResponse>(200, "ok response with body", example: new() { });
        Response<ErrorResponse>(400, "validation failure");
        Response(404, "films not found");
        Response(401, "not authorised");
    }
}
