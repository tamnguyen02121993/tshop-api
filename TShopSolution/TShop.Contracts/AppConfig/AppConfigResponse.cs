using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.AppConfig;

public record AppConfigResponse(
    int Id,
    string Key,
    string Value,
    Status Status
);