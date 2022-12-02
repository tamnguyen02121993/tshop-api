using FluentValidation;

namespace TShop.Api.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryValidator: AbstractValidator<GetBrandByIdQuery>
{
    public GetBrandByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}