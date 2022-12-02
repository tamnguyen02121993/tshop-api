using FluentValidation;
using TShop.Api.Models;

namespace TShop.Api.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandValidator: AbstractValidator<DeleteProductCommand>
{
	public DeleteProductCommandValidator()
	{
        RuleFor(x => x.Id).NotEmpty();
    }
}
