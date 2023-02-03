namespace StarWars.Mapping;

using Domain = Domain.Models;
using Response = Contracts.Responses;

public static class DomainToApiResponseContractMapper
{
    public static Response.CreateFilmResponse ToCreateFilmResponse(this Domain.Film film)
    {
        return new Response.CreateFilmResponse
        {
            Film = film.ToResponse()
        };
    }

    public static Response.Film ToResponse(this Domain.Film film)
    {
        return new Response.Film(
            episodeId: film.EpisodeId,
            title: film.Title,
            openingCrawl: film.OpeningCrawl,
            production: film.Production.ToResponse());

    }

    public static Response.Planet ToResponse(this Domain.Planet planet)
    {
        return new Response.Planet(
            name: planet.Name,
            diameter: planet.Diameter,
            gravity: planet.Gravity,
            orbitalPeriod: planet.OrbitalPeriod,
            population: planet.Population,
            rotationPeriod: planet.RotationPeriod,
            geography: planet.Geography.ToResponse());
    }

    public static Response.Geography ToResponse(this Domain.Geography geography)
    {
        return new Response.Geography(
            terrain: geography.Terrain,
            surfaceWater: geography.SurfaceWater, 
            climate: geography.Climate);
    }

    public static Response.Production ToResponse(this Domain.Production production)
    {
        return new Response.Production(
            director: production.Director,
            producer: production.Producer,
            releaseDate: production.ReleaseDate);

    }

    public static Response.GetFilmByIdResponse ToGetFilmByIdResponse(this Domain.Film film)
    {
        return new Response.GetFilmByIdResponse
        {
            Film = film.ToResponse()
        };
    }

    public static Response.GetPlanetByIdResponse ToGetPlanetByIdResponse(this Domain.Planet planet)
    {
        return new Response.GetPlanetByIdResponse
        {
            Planet = planet.ToResponse()
        };
    }

    public static Response.GetAllFilmsResponse ToGetAllFilmsResponse(this IEnumerable<Domain.Film> films)
    {
        return new Response.GetAllFilmsResponse
        {
            Count = films.Count(),
            Results = films.Select(result => result.ToResponse()).ToArray()
        };
    }

    public static Response.GetAllPlanetsResponse ToGetAllPlanetsResponse(this IEnumerable<Domain.Planet> planets)
    {
        return new Response.GetAllPlanetsResponse
        {
            Count = planets.Count(),
            Results = planets.Select(result => result.ToResponse()).ToArray()
        };
    }

    public static Response.SearchFilmsResponse ToSearchFilmsResponse(this IEnumerable<Domain.Film> films)
    {
        return new Response.SearchFilmsResponse
        {
            Count = films.Count(),
            Results = films.Select(result => result.ToResponse()).ToArray()
        };
    }

    public static Response.SearchPlanetsResponse ToSearchPlanetsResponse(this IEnumerable<Domain.Planet> planets)
    {
        return new Response.SearchPlanetsResponse
        {
            Count = planets.Count(),
            Results = planets.Select(result => result.ToResponse()).ToArray()
        };
    }
}