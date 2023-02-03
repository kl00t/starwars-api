using StarWars.Contracts.Data;

namespace StarWars.Repository;

public interface IStarWarsRepository
{
    Task<bool> CreateAsync(FilmDto film);

    Task<FilmDto?> GetAsync(Guid id);

    Task<IEnumerable<FilmDto>> GetAllAsync();

    Task<bool> UpdateAsync(FilmDto film);

    Task<bool> DeleteAsync(Guid id);
}