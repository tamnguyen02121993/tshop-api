using FluentValidation;

namespace TShop.Api.Features.Brands.Queries.GetAvailableBrandsPagination;

public class GetAllBrandsPaginationQueryValidator: AbstractValidator<GetAvailableBrandsPaginationQuery>
{
	public GetAllBrandsPaginationQueryValidator()
	{
		RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
