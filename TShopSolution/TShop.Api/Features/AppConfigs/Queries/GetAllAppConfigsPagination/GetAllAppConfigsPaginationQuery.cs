using MediatR;
using TShop.Contracts.AppConfig;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.AppConfigs.Queries.GetAllAppConfigsPagination;

public class GetAllAppConfigsPaginationQuery : IRequest<Pagination<AppConfigResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}
