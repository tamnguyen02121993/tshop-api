using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace TShop.Api.Services.Authentication;

public class JwtTokenProvider : IJwtTokenProvider
{
    private readonly IOptions<JwtConfig> _options;
    public JwtTokenProvider(IOptions<JwtConfig> options)
    {
        _options = options;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public string GenerateToken(string name, string email, List<string> roles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email)
            };

        foreach (var roleName in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, roleName));
        }
        var token = new JwtSecurityToken(issuer: _options.Value.Issuer,
                audience: _options.Value.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_options.Value.ExpiredTime),
                signingCredentials: credentials);


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
