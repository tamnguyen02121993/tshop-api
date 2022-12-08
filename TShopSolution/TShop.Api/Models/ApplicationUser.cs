using Microsoft.AspNetCore.Identity;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;

public class ApplicationUser: IdentityUser<int>
{
    public string? IdentityCode { get; set; }
    public DateTime? Birthday { get; set; }
    public Gender Gender { get; set; }
    public string? RefreshToken { get; set; } = string.Empty;
    public DateTime? RefreshTokenExpireTime { get; set; }
}
