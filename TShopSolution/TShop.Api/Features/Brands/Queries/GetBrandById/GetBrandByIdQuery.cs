using ErrorOr;
using MediatR;
using TShop.Contracts.Brand;

namespace TShop.Api.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQuery: IRequest<ErrorOr<BrandResponse>>
{
    public int Id { get; set; }
}