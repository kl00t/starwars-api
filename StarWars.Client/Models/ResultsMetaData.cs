using System.Text.Json.Serialization;

namespace StarWars.Client.Models;

public class ResultsMetaData
{
    /// <summary>
    /// Number of in the sequence
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// Next link.
    /// </summary>
    [JsonPropertyName("next")]
    public string Next { get; set; }

    /// <summary>
    /// Previous link.
    /// </summary>
    [JsonPropertyName("previous")]
    public string Previous { get; set; }
}
