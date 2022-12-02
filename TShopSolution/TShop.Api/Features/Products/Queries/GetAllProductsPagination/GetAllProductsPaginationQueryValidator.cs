using FluentValidation;

namespace TShop.Api.Features.Products.Queries.GetAllProductsPagination;

public class GetAllProductsPaginationQueryValidator : AbstractValidator<GetAllProductsPaginationQuery>
{
    public GetAllProductsPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
