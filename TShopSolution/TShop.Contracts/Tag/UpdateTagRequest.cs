using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Tag;

public record UpdateTagRequest(
    int Id,
    string Title,
    Status Status
);