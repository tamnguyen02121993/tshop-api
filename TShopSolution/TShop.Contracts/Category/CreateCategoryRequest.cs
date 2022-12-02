using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Category;

public record CreateCategoryRequest(
    string Name,
    string? Description,
    Status Status
);