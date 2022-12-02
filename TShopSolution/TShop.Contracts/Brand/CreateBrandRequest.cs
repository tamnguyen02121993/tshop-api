using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Brand;

public record CreateBrandRequest(
        string Name,
        string? Summary,
        Status Status
    );
