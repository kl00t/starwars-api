using StarWars.Contracts.Data;

namespace StarWars.Repository;

public class StarWarsRepository : IStarWarsRepository
{
    public StarWarsRepository()
    {
        
    }

    public async Task<bool> CreateAsync(FilmDto film)
    {
        //await _context.AddAsync(film);
        //var result = await _context.SaveChangesAsync();
        //return result > 0;
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return true;
    }

    public async Task<IEnumerable<FilmDto>> GetAllAsync()
    {
        return new List<FilmDto>().AsEnumerable();
    }

    public async Task<FilmDto?> GetAsync(Guid id)
    {
        return new FilmDto();
    }

    public async Task<bool> UpdateAsync(FilmDto film)
    {
        return true;
    }
}