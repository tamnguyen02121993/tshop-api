using FluentValidation;

namespace TShop.Api.Features.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

