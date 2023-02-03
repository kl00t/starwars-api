using StarWars.Api.Endpoints;
using StarWars.Contracts.Responses;

namespace StarWars.Api.Summaries;

public class CreateFilmSummary : Summary<CreateFilmEndpoint>
{
    private readonly CreateFilmResponse _exampleResponse = new()
    {
        Film = new Film(
            5, 
            "The Empire Strikes Back",
            "It is a dark time for the\r\nRebellion.",
            new Production(
                "Irvin Kershner", 
                "Gary Kurtz, " +
                "Rick McCallum", 
                new DateTime(1980, 5, 17)))
    };

    public CreateFilmSummary()
    {
        Summary = "Create a film endpoint.";
        Description = "Returns a CreateFilmResponse with the details of the created film.";
        Response(200, "ok response with body", example: _exampleResponse );
        Response<ErrorResponse>(400, "validation failure");
        Response(401, "not authorised");
    }
}