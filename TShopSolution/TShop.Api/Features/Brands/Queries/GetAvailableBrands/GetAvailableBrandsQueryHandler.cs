using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Brands;
using TShop.Contracts.Brand;

namespace TShop.Api.Features.Brands.Queries.GetAvailableBrands;

public class GetAvailableBrandsQueryHandler : IRequestHandler<GetAvailableBrandsQuery, List<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public GetAvailableBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }
    public async Task<List<BrandResponse>> Handle(GetAvailableBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAvailableBrands().ToListAsync();
        return _mapper.Map<List<BrandResponse>>(brands); 
    }
}