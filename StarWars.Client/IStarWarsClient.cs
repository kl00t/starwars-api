using StarWars.Client.Models;

namespace StarWars.Client;

public interface IStarWarsClient
{
    Task<FilmsResponse> GetAllFilms();

    Task<PlanetsResponse> GetAllPlanets();

    Task<Film> GetFilmById(int id);

    Task<Planet> GetPlanetById(int id);

    Task<FilmsResponse> SearchFilm(string searchQuery);

    Task<PlanetsResponse> SearchPlanet(string searchQuery);
}