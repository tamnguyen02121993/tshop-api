namespace TShop.Contracts.Authentication;

public record LoginResponse(
        string AccessToken,
        string RefreshToken,
        string Issuer,
        string Audience,
        string Name
    );