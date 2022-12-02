using MediatR;
using TShop.Contracts.Brand;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Brands.Queries.GetAvailableBrandsPagination;

public class GetAvailableBrandsPaginationQuery: IRequest<Pagination<BrandResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}
