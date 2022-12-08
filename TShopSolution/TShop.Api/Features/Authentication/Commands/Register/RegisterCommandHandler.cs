using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using TShop.Api.Utils;
using TShop.Contracts.Authentication;

namespace TShop.Api.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<UserResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<ErrorOr<UserResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userManager.FindByNameAsync(request.UserName);
            if (existUser is not null)
            {
                return Errors.Authentication.UserExisted;
            }
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                Birthday = request.Birthday,
            };

            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
            {
                return Errors.Authentication.CreateUserFailure;
            }
            if (!await _roleManager.RoleExistsAsync(Constants.CUSTOMER_ROLE))
            {
                return Errors.Authentication.RoleNotFound;
            }
            var addRoleResult = await _userManager.AddToRoleAsync(user, Constants.CUSTOMER_ROLE);
            if (!addRoleResult.Succeeded)
            {
                return Errors.Authentication.AddToRoleFailure;
            }
            return new UserResponse(user.Id, user.UserName, user.Email, user.Gender, user.PhoneNumber, user.Birthday);

        }
    }
}
