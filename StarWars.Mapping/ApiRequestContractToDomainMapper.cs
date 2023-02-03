namespace StarWars.Mapping;

using StarWars.Contracts.Requests;
using Domain = Domain.Models;

public static class ApiRequestContractToDomainMapper
{
    public static Domain.Film ToDomain(this CreateFilmRequest request)
    {
        return new Domain.Film(
            episodeId: request.EpisodeId,
            title: request.Title,
            openingCrawl: request.OpeningCrawl,
            director: request.Director,
            producer: request.Producer,
            releaseDate: request.ReleaseDate);
    }
}