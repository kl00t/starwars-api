using System.Text.Json.Serialization;

namespace StarWars.Client.Models;

public class Planet
{
    /// <summary>
    /// Name of the planet
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("climate")]
    public string Climate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("diameter")]
    public string Diameter { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("gravity")]
    public string Gravity { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("orbital_period")]
    public string OrbitalPeriod { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("population")]
    public string Population { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("rotation_period")]
    public string RotationPeriod { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("surface_water")]
    public string SurfaceWater { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("terrain")]
    public string Terrain { get; set; }
}