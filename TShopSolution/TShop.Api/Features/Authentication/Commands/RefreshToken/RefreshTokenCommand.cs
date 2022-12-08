using ErrorOr;
using MediatR;
using TShop.Contracts.Authentication;

namespace TShop.Api.Features.Authentication.Commands.RefreshToken;

public class RefreshTokenCommand: IRequest<ErrorOr<TokenResponse>>
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
