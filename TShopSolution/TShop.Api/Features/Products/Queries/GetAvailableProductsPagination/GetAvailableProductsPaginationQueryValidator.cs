using FluentValidation;

namespace TShop.Api.Features.Products.Queries.GetAvailableProductsPagination;

public class GetAllProductsPaginationQueryValidator : AbstractValidator<GetAvailableProductsPaginationQuery>
{
    public GetAllProductsPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
