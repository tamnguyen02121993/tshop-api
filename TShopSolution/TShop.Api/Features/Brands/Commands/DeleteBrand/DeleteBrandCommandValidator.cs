using FluentValidation;

namespace TShop.Api.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandValidator: AbstractValidator<DeleteBrandCommand>
{
    public DeleteBrandCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}