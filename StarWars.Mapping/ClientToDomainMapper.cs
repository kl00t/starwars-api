namespace StarWars.Mapping;

using StarWars.Domain.Extensions;
using Client = Client.Models;
using Domain = Domain.Models;

public static class ClientToDomainMapper
{
    public static Domain.Film ToDomain(this Client.Film film)
    {
        return new Domain.Film(
            episodeId: film.EpisodeId,
            title: film.Title,
            openingCrawl: film.OpeningCrawl,
            director: film.Director,
            producer: film.Producer,
            releaseDate: film.ReleaseDate.ToDateTime());
    }

    public static Domain.Planet ToDomain(this Client.Planet planet)
    {
        return new Domain.Planet(
            name: planet.Name,
            planet.Climate,
            planet.Diameter,
            planet.Gravity,
            planet.OrbitalPeriod,
            planet.Population,
            planet.RotationPeriod,
            planet.SurfaceWater,
            planet.Terrain);
    }

    public static IEnumerable<Domain.Film> ToDomain(this Client.Film[] films)
    {
        return (films.Select(film => film.ToDomain())).ToList();
    }   

    public static IEnumerable<Domain.Planet> ToDomain(this Client.Planet[] planets)
    {
        return (planets.Select(planet => planet.ToDomain())).ToList();
    }

    public static IEnumerable<Domain.Film> ToDomain(this Client.FilmsResponse filmsResponse)
    {
        return (filmsResponse.Results.Select(film => film.ToDomain())).ToList();
    }

    public static IEnumerable<Domain.Planet> ToDomain(this Client.PlanetsResponse planetsResponse)
    {
        return (planetsResponse.Results.Select(planet => planet.ToDomain())).ToList();
    }
}