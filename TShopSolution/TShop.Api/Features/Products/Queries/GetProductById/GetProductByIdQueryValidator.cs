using FluentValidation;

namespace TShop.Api.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryValidator: AbstractValidator<GetProductByIdQuery>
{
	public GetProductByIdQueryValidator()
	{
		RuleFor(x => x.Id).NotEmpty();
	}
}
