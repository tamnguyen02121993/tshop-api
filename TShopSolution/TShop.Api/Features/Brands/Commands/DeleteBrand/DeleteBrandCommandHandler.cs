using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Brands;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, ErrorOr<Deleted>>
{
    private readonly IBrandRepository _brandRepository;
    public DeleteBrandCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetBrandById(request.Id);
        if (brand is null)
        {
            return Errors.Brand.NotFound;
        }
        await _brandRepository.DeleteBrand(brand);

        return Result.Deleted;
    }
}