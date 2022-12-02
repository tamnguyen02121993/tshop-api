using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Features.Products.Commands.UpdateProduct;
using TShop.Api.Repositories.Products;
using TShop.Contracts.Product;
using TShop.Api.ServiceErrors;
using TShop.Api.Models;

namespace TShop.Api.Features.Products.Commands.UpdateProductImages;

public class UpdateProductImagesCommandHandler : IRequestHandler<UpdateProductImagesCommand, ErrorOr<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public UpdateProductImagesCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductResponse>> Handle(UpdateProductImagesCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.Id);
        if (product is null)
        {
            return Errors.Product.NotFound;
        }

        product.Images = request.Images.Select(x => new ProductImages { ProductId = product.Id, Url = x.Url }).ToList();
        await _productRepository.UpdateProduct(product);

        return _mapper.Map<ProductResponse>(product);
    }
}
