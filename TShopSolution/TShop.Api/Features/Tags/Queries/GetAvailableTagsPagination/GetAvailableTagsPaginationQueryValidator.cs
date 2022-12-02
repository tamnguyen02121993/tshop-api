using FluentValidation;

namespace TShop.Api.Features.Tags.Queries.GetAvailableTagsPagination;

public class GetAllTagsPaginationQueryValidator : AbstractValidator<GetAvailableTagsPaginationQuery>
{
    public GetAllTagsPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
