using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;

public class AppConfig : Auditable
{
    public int Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public Status Status { get; set; }
}
