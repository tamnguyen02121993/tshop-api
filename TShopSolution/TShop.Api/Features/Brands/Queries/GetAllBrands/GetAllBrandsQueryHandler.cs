using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Brands;
using TShop.Contracts.Brand;

namespace TShop.Api.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public GetAllBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }
    public async Task<List<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAllBrands().ToListAsync();
        return _mapper.Map<List<BrandResponse>>(brands); 
    }
}