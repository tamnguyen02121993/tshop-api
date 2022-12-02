using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Category;

public record CategoryResponse(
    int Id,
    string Name,
    string? Description,
    string SeoUrl,
    Status Status
);