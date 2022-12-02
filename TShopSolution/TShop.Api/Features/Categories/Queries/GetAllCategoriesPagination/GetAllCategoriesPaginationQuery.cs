using MediatR;
using TShop.Contracts.Category;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Categories.Queries.GetAllCategoriesPagination;

public class GetAllCategoriesPaginationQuery : IRequest<Pagination<CategoryResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}