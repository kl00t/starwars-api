namespace StarWars.Domain.Models;

public class Production
{
    public Production(string director, string producer, DateTime releaseDate)
    {
        Director = director;
        Producer = producer;
        ReleaseDate = releaseDate;
    }

    public string Director { get; internal set; }

    public string Producer { get; internal set; }

    public DateTime ReleaseDate { get; internal set; }
}