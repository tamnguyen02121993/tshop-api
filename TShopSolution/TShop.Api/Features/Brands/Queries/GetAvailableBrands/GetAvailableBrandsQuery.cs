using MediatR;
using TShop.Contracts.Brand;

namespace TShop.Api.Features.Brands.Queries.GetAvailableBrands;

public class GetAvailableBrandsQuery: IRequest<List<BrandResponse>>
{
    
}