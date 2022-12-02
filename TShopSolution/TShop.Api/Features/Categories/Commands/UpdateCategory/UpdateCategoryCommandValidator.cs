using FluentValidation;

namespace TShop.Api.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);

        RuleFor(x => x.Description).MaximumLength(500);

        RuleFor(x => x.Status).IsInEnum();
    }
}
