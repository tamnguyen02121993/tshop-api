using FluentValidation;

namespace TShop.Api.Features.AppConfigs.Queries.GetAppConfigById;

public class GetAppConfigByIdQueryValidator: AbstractValidator<GetAppConfigByIdQuery>
{
    public GetAppConfigByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}