using FluentValidation;

namespace TShop.Api.Features.Authentication.Commands.Login;

public class LoginCommandValidator: AbstractValidator<LoginCommand>
{
	public LoginCommandValidator()
	{
		RuleFor(x => x.UserName).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
