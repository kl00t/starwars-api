
using StarWars.Contracts.Requests;
using StarWars.Services;

namespace StarWars.Api.Endpoints;

public class UserLoginEndpoint : Endpoint<LoginRequest>
{
    private readonly IAuthService _authService;

    public UserLoginEndpoint(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        Post("login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var createTokenResponse = await _authService.CreateToken(req.Username, req.Password, ct);
        if (createTokenResponse.AreCredentialsValid)
        {
            await SendAsync(new
            {
                req.Username,
                createTokenResponse.Token
            }, cancellation: ct);
        }
        else
        {
            ThrowError("The supplied credentials are invalid!");
        }
    }
}