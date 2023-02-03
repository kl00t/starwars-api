namespace StarWars.Contracts.Responses;

public class GetAllPlanetsResponse : ResultsResponse
{
    public Planet[] Results { get; set; }
}