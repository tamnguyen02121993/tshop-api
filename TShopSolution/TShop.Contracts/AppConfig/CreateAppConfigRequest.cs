using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.AppConfig;

public record CreateAppConfigRequest(
    string Key,
    string Value,
    Status Status
);
