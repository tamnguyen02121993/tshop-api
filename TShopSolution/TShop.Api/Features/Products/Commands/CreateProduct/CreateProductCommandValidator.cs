using FluentValidation;

namespace TShop.Api.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Price).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Warranty).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.ImageUrl).NotEmpty();
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.BrandId).NotEmpty();
    }
}
