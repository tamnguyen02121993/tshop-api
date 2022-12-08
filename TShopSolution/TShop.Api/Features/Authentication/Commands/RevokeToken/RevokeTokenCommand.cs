using ErrorOr;
using MediatR;

namespace TShop.Api.Features.Authentication.Commands.RevokeToken;

public class RevokeTokenCommand: IRequest<ErrorOr<Updated>>
{
    public string Name { get; set; } = string.Empty;
}
