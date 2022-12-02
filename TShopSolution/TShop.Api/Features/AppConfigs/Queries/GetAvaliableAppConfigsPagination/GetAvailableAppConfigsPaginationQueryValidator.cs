using FluentValidation;

namespace TShop.Api.Features.AppConfigs.Queries.GetAvailableAppConfigsPagination;

public class GetAvailableAppConfigsPaginationQueryValidator : AbstractValidator<GetAvailableAppConfigsPaginationQuery>
{
    public GetAvailableAppConfigsPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
