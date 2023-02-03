using System.Text.Json.Serialization;

namespace StarWars.Client.Models;

public class FilmsResponse : ResultsMetaData
{
    /// Array of planet results
    /// </summary>
    [JsonPropertyName("results")]
    public Film[] Results { get; set; }
}
