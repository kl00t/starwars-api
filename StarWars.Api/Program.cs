global using FastEndpoints;
global using FastEndpoints.Security;

using FastEndpoints.Swagger;
using Serilog;
using StarWars.Client;
using StarWars.Repository;
using StarWars.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();

var key = Environment.GetEnvironmentVariable(StarWars.Domain.Constants.EnvironmentConstants.TokenSigningKey);
builder.Services.AddJWTBearerAuth(key);
//builder.Services.AddAuthenticationJWTBearer(key);
builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "Star Wars API";
    settings.Version = "v1";
    settings.Description = "Consumes the Star Wars API at https://swapi.dev/api/";
});
builder.Services.AddResponseCaching();
builder.Services.AddStarWarsServices();
builder.Services.AddStarWarsRepository();
builder.Services.AddStarWarsApiClient(builder.Configuration);
builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();
app.Logger.LogInformation("The StarWars.Api has started at {Date}.", DateTime.UtcNow);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();
app.UseFastEndpoints(c =>
{
    c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    c.Endpoints.RoutePrefix = "api";
});
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();