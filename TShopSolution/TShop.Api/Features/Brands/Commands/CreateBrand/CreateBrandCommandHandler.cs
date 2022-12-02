using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Models;
using TShop.Api.Repositories.Brands;
using TShop.Contracts.Brand;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ErrorOr<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<BrandResponse>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = _mapper.Map<Brand>(request);

        var createdBrand = await _brandRepository.CreateBrand(brand);

        if (createdBrand is not null)
        {
            return _mapper.Map<BrandResponse>(createdBrand);
        }

        return Errors.Brand.NotFound;
    }
}