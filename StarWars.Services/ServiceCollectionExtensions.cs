using Microsoft.Extensions.DependencyInjection;

namespace StarWars.Services;

public static partial class ServiceCollectionExtensions
{
    public static void AddStarWarsServices(this IServiceCollection services)
    {
        services.AddSingleton<IStarWarsService, StarWarsService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}