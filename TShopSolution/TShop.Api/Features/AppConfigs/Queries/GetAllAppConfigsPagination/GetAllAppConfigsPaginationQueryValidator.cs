using FluentValidation;

namespace TShop.Api.Features.AppConfigs.Queries.GetAllAppConfigsPagination;

public class GetAllAppConfigsPaginationQueryValidator : AbstractValidator<GetAllAppConfigsPaginationQuery>
{
    public GetAllAppConfigsPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
