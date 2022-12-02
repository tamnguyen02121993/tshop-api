using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Brand;

public record UpdateBrandRequest(
    int Id,
    string Name,
    string? Summary,
    Status Status
);