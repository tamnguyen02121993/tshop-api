using FluentValidation;

namespace TShop.Api.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandValidator: AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Summary).MaximumLength(500);
        RuleFor(x => x.Status).IsInEnum();
    }
}