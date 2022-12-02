using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Products;
using TShop.Contracts.Product;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Products.Queries.GetAllProductsPagination;

public class GetAllProductsPaginationQueryHandler : IRequestHandler<GetAllProductsPaginationQuery, Pagination<ProductResponse>>
{
    private readonly IProductRepository _brandRepository;
    private readonly IMapper _mapper;
    public GetAllProductsPaginationQueryHandler(IProductRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<ProductResponse>> Handle(GetAllProductsPaginationQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAllProducts(request.PageIndex, request.PageSize, request.Search);
        var brandsResponse = _mapper.Map<Pagination<ProductResponse>>(brands);

        return brandsResponse;
    }
}
