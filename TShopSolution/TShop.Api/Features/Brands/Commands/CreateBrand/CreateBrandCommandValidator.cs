using FluentValidation;

namespace TShop.Api.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator: AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Summary).MaximumLength(500);
        RuleFor(x => x.Status).IsInEnum();
    }
}