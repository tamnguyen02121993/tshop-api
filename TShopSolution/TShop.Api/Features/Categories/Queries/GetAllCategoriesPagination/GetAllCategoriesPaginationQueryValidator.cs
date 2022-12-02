using FluentValidation;

namespace TShop.Api.Features.Categories.Queries.GetAllCategoriesPagination;

public class GetAvailableCategoriesPaginationQueryValidator: AbstractValidator<GetAllCategoriesPaginationQuery>
{
	public GetAvailableCategoriesPaginationQueryValidator()
	{
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
