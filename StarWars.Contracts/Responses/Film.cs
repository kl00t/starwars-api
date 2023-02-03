namespace StarWars.Contracts.Responses;

public class Film
{
    public Film(int episodeId, string title, string openingCrawl, Production production)
    {
        EpisodeId = episodeId;
        Title = title;
        OpeningCrawl = openingCrawl;
        Production = production;
    }

    public int EpisodeId { get; internal set; }

    public string Title { get; internal set; }

    public string OpeningCrawl { get; internal set; }

    public Production Production { get; set; }
}