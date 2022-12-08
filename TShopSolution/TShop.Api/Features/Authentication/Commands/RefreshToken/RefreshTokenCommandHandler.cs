using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using TShop.Api.Services.Authentication;
using TShop.Contracts.Authentication;

namespace TShop.Api.Features.Authentication.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ErrorOr<TokenResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtTokenProvider _tokenProvider;
    private readonly IOptions<JwtConfig> _jwtConfigOptions;
    public RefreshTokenCommandHandler(UserManager<ApplicationUser> userManager, IJwtTokenProvider tokenProvider, IOptions<JwtConfig> jwtConfigOptions)
    {
        _userManager = userManager;
        _tokenProvider = tokenProvider;
        _jwtConfigOptions = jwtConfigOptions;
    }

    public async Task<ErrorOr<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var claimsPrincipal = GetPrincipalFromAccessToken(request.AccessToken);
        if (claimsPrincipal is null)
        {
            return Errors.Authentication.InvalidToken;
        }
        var userName = claimsPrincipal.Identity!.Name;
        var user = await _userManager.FindByNameAsync(userName);
        if (user is null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpireTime <= DateTime.UtcNow)
        {
            return Errors.Authentication.InvalidToken;
        }
        var roles = (await _userManager.GetRolesAsync(user)).ToList();
        var newAccessToken = _tokenProvider.GenerateToken(user.UserName, user.Email, roles);
        var newRefreshToken = _tokenProvider.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpireTime = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        return new TokenResponse(newAccessToken, newRefreshToken);
    }

    private ClaimsPrincipal? GetPrincipalFromAccessToken(string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfigOptions.Value.Key)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            return null;

        return principal;
    }
}
