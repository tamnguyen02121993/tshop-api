using ErrorOr;
using MediatR;
using TShop.Contracts.Authentication;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Authentication.Commands.Register;

public class RegisterCommand: IRequest<ErrorOr<UserResponse>>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? Birthday { get; set; }
}
