using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Products;
using TShop.Contracts.Product;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ErrorOr<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.Id);
        if (product is not null)
        {
            return _mapper.Map<ProductResponse>(product);
        }

        return Errors.Product.NotFound;
    }
}
