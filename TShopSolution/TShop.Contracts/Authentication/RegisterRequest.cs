using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Authentication;

public record RegisterRequest(
        string UserName,
        string Email,
        string Password,
        string ConfirmPassword,
        Gender Gender,
        string? PhoneNumber,
        DateTime? Birthday
    );
