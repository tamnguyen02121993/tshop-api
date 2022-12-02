using MediatR;
using TShop.Contracts.Tag;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Tags.Queries.GetAllTagsPagination;

public class GetAllTagsPaginationQuery : IRequest<Pagination<TagResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}
