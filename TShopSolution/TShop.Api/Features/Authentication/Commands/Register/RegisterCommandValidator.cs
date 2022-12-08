using FluentValidation;

namespace TShop.Api.Features.Authentication.Commands.Register;

public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
		RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password);
    }
}
