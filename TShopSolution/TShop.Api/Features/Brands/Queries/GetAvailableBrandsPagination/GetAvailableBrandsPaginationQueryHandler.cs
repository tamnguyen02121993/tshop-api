using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Brands;
using TShop.Contracts.Brand;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Brands.Queries.GetAvailableBrandsPagination;

public class GetAllBrandsPaginationQueryHandler : IRequestHandler<GetAvailableBrandsPaginationQuery, Pagination<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public GetAllBrandsPaginationQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<BrandResponse>> Handle(GetAvailableBrandsPaginationQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAvailableBrands(request.PageIndex, request.PageSize, request.Search);
        var brandsResponse = _mapper.Map<Pagination<BrandResponse>>(brands);

        return brandsResponse;
    }
}
