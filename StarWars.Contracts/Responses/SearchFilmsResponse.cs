namespace StarWars.Contracts.Responses;

public class SearchFilmsResponse : ResultsResponse
{
    public Film[] Results { get; set; }
}