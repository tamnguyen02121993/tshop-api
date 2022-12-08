using FluentValidation;

namespace TShop.Api.Features.Authentication.Commands.RevokeToken;

public class RevokeTokenCommandValidator: AbstractValidator<RevokeTokenCommand>
{
	public RevokeTokenCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty();
	}
}
