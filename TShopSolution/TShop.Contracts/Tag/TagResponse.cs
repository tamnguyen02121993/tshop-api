using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Tag;

public record TagResponse(
    int Id,
    string Title,
    string Slug,
    Status Status
);