namespace StarWars.Services;

public interface IAuthService
{
    Task<CreateTokenResponse> CreateToken(string username, string password, CancellationToken ct);
}