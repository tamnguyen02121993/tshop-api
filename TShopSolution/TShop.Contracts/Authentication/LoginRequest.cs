namespace TShop.Contracts.Authentication;

public record LoginRequest(
        string UserName,
        string Password,
        bool RememberMe
    );
