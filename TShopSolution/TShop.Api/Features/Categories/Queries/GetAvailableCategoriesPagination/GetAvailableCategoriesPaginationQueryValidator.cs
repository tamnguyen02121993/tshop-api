using FluentValidation;

namespace TShop.Api.Features.Categories.Queries.GetAllCategoriesPagination;

public class GetAllCategoriesPaginationQueryValidator: AbstractValidator<GetAllCategoriesPaginationQuery>
{
	public GetAllCategoriesPaginationQueryValidator()
	{
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
