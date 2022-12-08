namespace TShop.Api.Services.Authentication;

public interface IJwtTokenProvider
{
    string GenerateToken(string name, string email, List<string> roles);
    string GenerateRefreshToken();
}
