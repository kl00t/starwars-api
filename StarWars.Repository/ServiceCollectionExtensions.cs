using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace StarWars.Repository;

public static partial class ServiceCollectionExtensions
{
    public static void AddStarWarsRepository(this IServiceCollection services)
    {
        //services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("StarWarsDb"));
        services.AddSingleton<IStarWarsRepository, StarWarsRepository>();
    }
}