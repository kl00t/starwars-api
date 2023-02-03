namespace StarWars.Services;

public interface IStarWarsService
{
    Task<Domain.Models.Film> CreateFilm(Domain.Models.Film film);

    Task<IEnumerable<Domain.Models.Film>> GetAllFilms();

    Task<IEnumerable<Domain.Models.Planet>> GetAllPlanets();

    Task<Domain.Models.Film> GetFilmById(int id);

    Task<Domain.Models.Planet> GetPlanetById(int id);

    Task<IEnumerable<Domain.Models.Film>> SearchFilm(string searchQuery);

    Task<IEnumerable<Domain.Models.Planet>> SearchPlanet(string searchQuery);
}