namespace StarWars.Contracts.Responses;

public class SearchPlanetsResponse : ResultsResponse
{
    public Planet[] Results { get; set; }
}