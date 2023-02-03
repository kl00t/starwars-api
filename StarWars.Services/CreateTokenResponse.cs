namespace StarWars.Services;

public class CreateTokenResponse
{
    public CreateTokenResponse()
    {
        AreCredentialsValid = false;
    }

    public CreateTokenResponse(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        AreCredentialsValid = true;
        Token = token;
    }

    public bool AreCredentialsValid { get; internal set; }

    public string Token { get; internal set; }
}