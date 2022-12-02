using MediatR;
using TShop.Contracts.Brand;

namespace TShop.Api.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQuery: IRequest<List<BrandResponse>>
{
    
}