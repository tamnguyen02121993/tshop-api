using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.AppConfig;

public record UpdateAppConfigRequest(
    int Id, 
    string Key,
    string Value,
    Status Status
);