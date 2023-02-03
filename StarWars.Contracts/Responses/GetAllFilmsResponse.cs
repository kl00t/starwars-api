namespace StarWars.Contracts.Responses;

public class GetAllFilmsResponse : ResultsResponse
{
    public Film[] Results { get; set; }
}