using MediatR;
using TShop.Contracts.Product;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Products.Queries.GetAllProductsPagination;

public class GetAllProductsPaginationQuery : IRequest<Pagination<ProductResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}
