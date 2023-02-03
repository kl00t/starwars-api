using FastEndpoints.Security;
using StarWars.Domain.Constants;

namespace StarWars.Services;

public class AuthService : IAuthService
{
    public async Task<CreateTokenResponse> CreateToken(string username, string password, CancellationToken ct)
    {
        if (await CredentialsAreValid(username, password))
        {
            var jwtToken = JWTBearer.CreateToken(
                signingKey: Environment.GetEnvironmentVariable(EnvironmentConstants.TokenSigningKey),
                expireAt: DateTime.UtcNow.AddDays(1),
                claims: new[] { (Claims.Username, username) },
                roles: new[] { Roles.Admin, Roles.Management },
                permissions: new[]
                {
                    Domain.Constants.Permissions.GetFilmPermission,
                    Domain.Constants.Permissions.GetPlanetPermision,
                    Domain.Constants.Permissions.CreateFilmPermission,
                    Domain.Constants.Permissions.CreatePlanetPermission
                });

            return new CreateTokenResponse(jwtToken);
        }

        return new CreateTokenResponse();
    }

    private static async Task<bool> CredentialsAreValid(string username, string password)
    {
        bool result = false;
        if (username == Environment.GetEnvironmentVariable(EnvironmentConstants.Username)
            && password == Environment.GetEnvironmentVariable(EnvironmentConstants.Password))
        {
            result = true;
        }

        return result;
    }
}