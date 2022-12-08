using FluentValidation;

namespace TShop.Api.Features.Authentication.Queries.GetUserByEmail;

public class GetUserByEmailQueryValidator: AbstractValidator<GetUserByEmailQuery>
{
	public GetUserByEmailQueryValidator()
	{
		RuleFor(x => x.Email).NotEmpty();
	}
}
