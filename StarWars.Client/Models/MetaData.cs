using System.Text.Json.Serialization;

namespace StarWars.Client.Models;

public class MetaData
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("edited")]
    public DateTime Edited { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}