using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Authentication;

public record UserResponse(
        int Id,
        string Name,
        string Email,
        Gender Gender,
        string? PhoneNumber,
        DateTime? Birthday
    );
