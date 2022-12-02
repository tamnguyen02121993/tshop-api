using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Brands;
using TShop.Contracts.Brand;
using TShop.Api.ServiceErrors;
using MapsterMapper;

namespace TShop.Api.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, ErrorOr<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public GetBrandByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<BrandResponse>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetBrandById(request.Id);
        if (brand is not null)
        {
            return _mapper.Map<BrandResponse>(brand);
        }

        return Errors.Brand.NotFound;
    }
}