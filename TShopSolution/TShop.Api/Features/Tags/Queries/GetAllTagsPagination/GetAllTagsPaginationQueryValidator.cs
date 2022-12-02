using FluentValidation;

namespace TShop.Api.Features.Tags.Queries.GetAllTagsPagination;

public class GetAllTagsPaginationQueryValidator : AbstractValidator<GetAllTagsPaginationQuery>
{
    public GetAllTagsPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
