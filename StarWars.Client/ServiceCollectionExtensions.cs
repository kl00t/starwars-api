namespace StarWars.Client;

public static class ServiceCollectionExtensions
{
    //public static void AddStarWarsApiClient(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddSingleton<IStarWarsClient, StarWarsClient>();

    //    var starWarsApiOptions = new StarWarsApiOptions();
    //    var starWarsApiOptionsSection = configuration.GetSection(nameof(StarWarsApiOptions));
    //    starWarsApiOptionsSection.Bind(starWarsApiOptions);
    //    services.Configure<StarWarsApiOptions>(starWarsApiOptionsSection);
    //    services.AddHttpClient("starwarsapi", client =>
    //    {
    //        client.BaseAddress = new Uri(starWarsApiOptions.BaseAddress);
    //    });
    //}
}