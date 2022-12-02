using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Products;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Deleted>>
{
    private readonly IProductRepository _productRepository;
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.Id);
        if (product is null)
        {
            return Errors.Product.NotFound;
        }
        await _productRepository.DeleteProduct(product);

        return Result.Deleted;
    }
}
