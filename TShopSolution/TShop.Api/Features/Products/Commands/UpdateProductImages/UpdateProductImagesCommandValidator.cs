using FluentValidation;

namespace TShop.Api.Features.Products.Commands.UpdateProductImages;

public class UpdateProductImagesCommandValidator: AbstractValidator<UpdateProductImagesCommand>
{
	public UpdateProductImagesCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty();
		RuleFor(x => x.Images).NotEmpty();
	}
}
