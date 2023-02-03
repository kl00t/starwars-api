using Microsoft.Extensions.Logging;
using StarWars.Client;
using StarWars.Domain.Models;
using StarWars.Mapping;
using StarWars.Repository;

namespace StarWars.Services;

public class StarWarsService : IStarWarsService
{
    private readonly ILogger<StarWarsService> _logger;
    private readonly IStarWarsClient _starWarsClient;
    private readonly IStarWarsRepository _starWarsRepository;

    public StarWarsService(
        ILogger<StarWarsService> logger, 
        IStarWarsClient starWarsClient, 
        IStarWarsRepository starWarsRepository)
    {
        _logger = logger;
        _starWarsClient = starWarsClient;
        _starWarsRepository = starWarsRepository;
    }

    public async Task<Film> CreateFilm(Film film)
    {
        _logger.LogInformation("Calling {service}", nameof(StarWarsService.CreateFilm));
        var result = await _starWarsRepository.CreateAsync(new Contracts.Data.FilmDto { Id = Guid.NewGuid().ToString(), Title = "Jedi" });
        if (result)
        {
            return film;
        }

        return film;
    }

    public async Task<IEnumerable<Domain.Models.Film>> GetAllFilms()
    {
        _logger.LogInformation("Calling {service}", nameof(StarWarsService.GetAllFilms));
        var response = await _starWarsClient.GetAllFilms();
        return response.ToDomain();
    }

    public async Task<IEnumerable<Domain.Models.Planet>> GetAllPlanets()
    {
        _logger.LogInformation("Calling {service}", nameof(StarWarsService.GetAllPlanets));
        var response = await _starWarsClient.GetAllPlanets();
        return response.ToDomain();
    }

    public async Task<Domain.Models.Film> GetFilmById(int id)
    {
        _logger.LogInformation("Calling {service}", nameof(StarWarsService.GetFilmById));
        var response = await _starWarsClient.GetFilmById(id);
        return response.ToDomain();
    }

    public async Task<Domain.Models.Planet> GetPlanetById(int id)
    {
        _logger.LogInformation("Calling {service}", nameof(StarWarsService.GetPlanetById));
        var response = await _starWarsClient.GetPlanetById(id);
        return response.ToDomain();
    }

    public async Task<IEnumerable<Domain.Models.Film>> SearchFilm(string searchQuery)
    {
        _logger.LogInformation("Calling {service}", nameof(StarWarsService.SearchFilm));
        var response = await _starWarsClient.SearchFilm(searchQuery);
        return response.ToDomain();
    }

    public async Task<IEnumerable<Domain.Models.Planet>> SearchPlanet(string searchQuery)
    {
        _logger.LogInformation("Calling {service}", nameof(StarWarsService.SearchPlanet));
        var response = await _starWarsClient.SearchPlanet(searchQuery);
        return response.ToDomain();
    }
}