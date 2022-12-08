using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using TShop.Contracts.Authentication;

namespace TShop.Api.Features.Authentication.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, ErrorOr<UserResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public GetUserByEmailQueryHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ErrorOr<UserResponse>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Errors.Authentication.UserNotFound;
        }

        return new UserResponse(user.Id, user.UserName, user.Email, user.Gender, user.PhoneNumber, user.Birthday);
    }
}
