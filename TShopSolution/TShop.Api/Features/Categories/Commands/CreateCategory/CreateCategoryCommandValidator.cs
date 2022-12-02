using FluentValidation;

namespace TShop.Api.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(255);

        RuleFor(c => c.Description).MaximumLength(500);

        RuleFor(c => c.Status).IsInEnum();
    }
}
