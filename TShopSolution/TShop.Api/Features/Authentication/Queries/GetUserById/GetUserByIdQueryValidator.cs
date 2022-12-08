using FluentValidation;

namespace TShop.Api.Features.Authentication.Queries.GetUserById;

public class GetUserByIdQueryValidator: AbstractValidator<GetUserByIdQuery>
{
	public GetUserByIdQueryValidator()
	{
		RuleFor(x => x.Id).NotEmpty();
	}
}
