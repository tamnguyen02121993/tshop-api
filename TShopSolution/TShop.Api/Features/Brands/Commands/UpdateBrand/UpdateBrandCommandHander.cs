using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Brands;
using TShop.Contracts.Brand;
using TShop.Api.ServiceErrors;
using TShop.Api.Models;

namespace TShop.Api.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, ErrorOr<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    
    public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<BrandResponse>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetBrandById(request.Id);
        if (brand is null)
        {
            return Errors.Brand.NotFound;
        }

        var updatedBrand = _mapper.Map<UpdateBrandCommand, Brand>(request, brand);
        await _brandRepository.UpdateBrand(updatedBrand);

        return _mapper.Map<BrandResponse>(updatedBrand);
    }
}