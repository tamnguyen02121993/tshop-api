using ErrorOr;
using MediatR;
using TShop.Contracts.Authentication;

namespace TShop.Api.Features.Authentication.Commands.Login;

public class LoginCommand: IRequest<ErrorOr<LoginResponse>>
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; }
}
