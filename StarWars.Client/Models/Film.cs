using System.Text.Json.Serialization;

namespace StarWars.Client.Models;

public class Film : MetaData
{
    /// <summary>
    /// Name of the film
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// Episode Id
    /// </summary>
    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; set; }

    /// <summary>
    /// Opening credits crawl text.
    /// </summary>
    [JsonPropertyName("opening_crawl")]
    public string OpeningCrawl { get; set; }

    /// <summary>
    /// Director of the film.
    /// </summary>
    [JsonPropertyName("director")]
    public string Director { get; set; }

    /// <summary>
    /// Producer(s) of the film.
    /// </summary>
    [JsonPropertyName("producer")]
    public string Producer { get; set; }

    /// <summary>
    /// Release date of the film.
    /// </summary>
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
}