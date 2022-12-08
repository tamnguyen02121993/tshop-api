using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using TShop.Api.Services.Authentication;
using TShop.Contracts.Authentication;

namespace TShop.Api.Features.Authentication.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<LoginResponse>>
{
    private readonly IJwtTokenProvider _tokenProvider;
    private readonly IOptions<JwtConfig> _jwtConfigOptions;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginCommandHandler(IJwtTokenProvider tokenProvider, IOptions<JwtConfig> options, UserManager<ApplicationUser> userManager)
    {
        _tokenProvider = tokenProvider;
        _userManager = userManager;
        _jwtConfigOptions = options;
    }
    public async Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null)
        {
            return Errors.Authentication.UserNotFound;
        }

        var checkPasswordResult = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!checkPasswordResult)
        {
            return Errors.Authentication.CredentialInvalid;
        }

        var roles = (await _userManager.GetRolesAsync(user)).ToList();
        var token = _tokenProvider.GenerateToken(user.UserName, user.Email, roles);
        var refreshToken = _tokenProvider.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpireTime = DateTime.UtcNow.AddMinutes(_jwtConfigOptions.Value.RefreshTokenExpiredTime);

        await _userManager.UpdateAsync(user);

        return new LoginResponse(token,
            refreshToken,
            _jwtConfigOptions.Value.Audience,
            _jwtConfigOptions.Value.Issuer);
    }
}
