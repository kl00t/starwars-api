namespace StarWars.Domain.Models;

public class Film
{
	public Film(int episodeId, string title, string openingCrawl, string director, string producer, DateTime releaseDate)
	{
        EpisodeId = episodeId;
		Title = title;
        OpeningCrawl = openingCrawl;
        Production = new Production(
            director: director,
            producer: producer, 
            releaseDate: releaseDate);
	}

    public string Title { get; internal set; }

    public int EpisodeId { get; internal set; }

    public string OpeningCrawl { get; internal set; }

    public Production Production { get; set; }
}