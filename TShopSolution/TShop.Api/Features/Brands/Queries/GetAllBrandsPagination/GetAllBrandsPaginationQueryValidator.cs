using FluentValidation;

namespace TShop.Api.Features.Brands.Queries.GetAllBrandsPagination;

public class GetAllBrandsPaginationQueryValidator: AbstractValidator<GetAllBrandsPaginationQuery>
{
	public GetAllBrandsPaginationQueryValidator()
	{
		RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
