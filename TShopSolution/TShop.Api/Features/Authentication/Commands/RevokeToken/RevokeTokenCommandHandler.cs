using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.Authentication.Commands.RevokeToken;

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, ErrorOr<Updated>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public RevokeTokenCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ErrorOr<Updated>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Name);
        if (user is null)
        {
            return Errors.Authentication.UserNotFound;
        }

        user.RefreshToken = null;
        await _userManager.UpdateAsync(user);
        return Result.Updated;
    }
}
