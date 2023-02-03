using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWars.Client.Configuration;
using StarWars.Client.Models;
using System.Net.Http.Json;

namespace StarWars.Client;

public class StarWarsClient : IStarWarsClient
{
    private readonly ILogger<StarWarsClient> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly StarWarsApiOptions _starWarsApiOptions;

    public StarWarsClient(
        ILogger<StarWarsClient> logger, 
        IHttpClientFactory httpClientFactory,
        IOptionsMonitor<StarWarsApiOptions> starWarsApiOptions)
    {
        _httpClientFactory = httpClientFactory;
        _starWarsApiOptions = starWarsApiOptions.CurrentValue;
        _logger = logger;
    }

    public async Task<FilmsResponse> GetAllFilms()
    {
        var httpClient = _httpClientFactory.CreateClient(_starWarsApiOptions.ClientName);
        var response = await httpClient.GetAsync($"films/");
        _logger.LogInformation("{requestUri}", response.RequestMessage.RequestUri);
        return await response.Content.ReadFromJsonAsync<FilmsResponse>();
    }

    public async Task<PlanetsResponse> GetAllPlanets()
    {
        var httpClient = _httpClientFactory.CreateClient(_starWarsApiOptions.ClientName);
        var response = await httpClient.GetAsync($"planets/");
        _logger.LogInformation("{method}: {requestUri}", response.RequestMessage.Method, response.RequestMessage.RequestUri);
        return await response.Content.ReadFromJsonAsync<PlanetsResponse>();
    }

    public async Task<Film> GetFilmById(int id)
    {
        var httpClient = _httpClientFactory.CreateClient(_starWarsApiOptions.ClientName);
        var response = await httpClient.GetAsync($"films/{id}");
        _logger.LogInformation("{method}: {requestUri}", response.RequestMessage.Method, response.RequestMessage.RequestUri);
        return await response.Content.ReadFromJsonAsync<Film>();
    }

    public async Task<Planet> GetPlanetById(int id)
    {
        var httpClient = _httpClientFactory.CreateClient(_starWarsApiOptions.ClientName);
        var response = await httpClient.GetAsync($"planets/{id}");
        _logger.LogInformation("{method}: {requestUri}", response.RequestMessage.Method, response.RequestMessage.RequestUri);
        return await response.Content.ReadFromJsonAsync<Planet>();
    }

    public async Task<FilmsResponse> SearchFilm(string searchQuery)
    {
        var httpClient = _httpClientFactory.CreateClient(_starWarsApiOptions.ClientName);
        var response = await httpClient.GetAsync($"films/?search={searchQuery}");
        _logger.LogInformation("{method}: {requestUri}", response.RequestMessage.Method, response.RequestMessage.RequestUri);
        return await response.Content.ReadFromJsonAsync<FilmsResponse>();
    }

    public async Task<PlanetsResponse> SearchPlanet(string searchQuery)
    {
        var httpClient = _httpClientFactory.CreateClient(_starWarsApiOptions.ClientName);
        var response = await httpClient.GetAsync($"planets/?search={searchQuery}");
        _logger.LogInformation("{method}: {requestUri}", response.RequestMessage.Method, response.RequestMessage.RequestUri);
        return await response.Content.ReadFromJsonAsync<PlanetsResponse>();
    }
}