using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Products;
using TShop.Contracts.Product;

namespace TShop.Api.Features.Products.Queries.GetAvailableProducts;

public class GetAvailableProductsQueryHandler : IRequestHandler<GetAvailableProductsQuery, List<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetAvailableProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<List<ProductResponse>> Handle(GetAvailableProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAvailableProducts().ToListAsync();
        return _mapper.Map<List<ProductResponse>>(products);
    }
}
