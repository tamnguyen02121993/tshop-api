using FluentValidation;

namespace TShop.Api.Features.Tags.Queries.GetTagById;

public class GetTagByIdQueryValidator: AbstractValidator<GetTagByIdQuery>
{
    public GetTagByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}