using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.AppConfigs;
using TShop.Api.Repositories.Products;
using TShop.Contracts.AppConfig;
using TShop.Contracts.Product;

namespace TShop.Api.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<List<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllProducts().ToListAsync();
        return _mapper.Map<List<ProductResponse>>(products);
    }
}
