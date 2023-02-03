namespace StarWars.Api.Events;

public class CreateFilmEvent
{
    public int EpisodeId { get; set; }

    public string Title { get; set; }
}