namespace TShop.Api.Services.Authentication;

public class JwtConfig
{
    public const string JWT_SECTION = "JwtConfig";
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpiredTime { get; set; }
    public int RefreshTokenExpiredTime { get; set; }
}
