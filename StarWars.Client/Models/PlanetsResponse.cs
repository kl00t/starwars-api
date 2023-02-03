using System.Text.Json.Serialization;

namespace StarWars.Client.Models;

public class PlanetsResponse : ResultsMetaData
{
    /// Array of planet results
    /// </summary>
    [JsonPropertyName("results")]
    public Planet[] Results { get; set; }
}