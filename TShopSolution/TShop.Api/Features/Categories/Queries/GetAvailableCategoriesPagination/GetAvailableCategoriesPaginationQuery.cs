using MediatR;
using TShop.Contracts.Category;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Categories.Queries.GetAvailableCategoriesPagination;

public class GetAvailableCategoriesPaginationQuery : IRequest<Pagination<CategoryResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}