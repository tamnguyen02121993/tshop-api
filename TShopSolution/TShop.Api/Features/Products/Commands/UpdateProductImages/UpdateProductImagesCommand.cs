using ErrorOr;
using MediatR;
using TShop.Contracts.Product;

namespace TShop.Api.Features.Products.Commands.UpdateProductImages;

public class UpdateProductImagesCommand: IRequest<ErrorOr<ProductResponse>>
{
    public Guid Id { get; set; }
    public List<ProductImage> Images { get; set; }
}
