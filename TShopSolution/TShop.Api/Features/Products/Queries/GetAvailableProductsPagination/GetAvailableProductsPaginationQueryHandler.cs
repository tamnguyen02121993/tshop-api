using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Products;
using TShop.Contracts.Product;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Products.Queries.GetAvailableProductsPagination;

public class GetAllProductsPaginationQueryHandler : IRequestHandler<GetAvailableProductsPaginationQuery, Pagination<ProductResponse>>
{
    private readonly IProductRepository _brandRepository;
    private readonly IMapper _mapper;
    public GetAllProductsPaginationQueryHandler(IProductRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<ProductResponse>> Handle(GetAvailableProductsPaginationQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAvailableProducts(request.PageIndex, request.PageSize, request.Search);
        var brandsResponse = _mapper.Map<Pagination<ProductResponse>>(brands);

        return brandsResponse;
    }
}
