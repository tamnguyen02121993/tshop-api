using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using TShop.Contracts.Authentication;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Authentication.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public GetUserByIdQueryHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<ErrorOr<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
        {
            return Errors.Authentication.UserNotFound;
        }

        return new UserResponse(user.Id, user.UserName, user.Email, user.Gender, user.PhoneNumber, user.Birthday);
    }
}
