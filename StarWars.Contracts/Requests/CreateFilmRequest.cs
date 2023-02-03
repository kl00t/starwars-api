namespace StarWars.Contracts.Requests;

public class CreateFilmRequest
{
    public int EpisodeId { get; set; }

    public string Title { get; set; }

    public string OpeningCrawl { get; set; }

    public string Director { get; set; }

    public string Producer { get; set; }

    public DateTime ReleaseDate { get; set; }
}