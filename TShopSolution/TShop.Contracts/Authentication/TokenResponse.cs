namespace TShop.Contracts.Authentication;

public record TokenResponse(
        string AccessToken,
        string RefreshToken
    );
