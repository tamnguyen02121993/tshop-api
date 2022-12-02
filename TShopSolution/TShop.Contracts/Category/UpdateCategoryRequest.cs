using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Category;

public record UpdateCategoryRequest(
    int Id,
    string Name,
    string? Description,
    Status Status
);