using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Tag;

public record CreateTagRequest(
        string Title,
        Status Status
    );
