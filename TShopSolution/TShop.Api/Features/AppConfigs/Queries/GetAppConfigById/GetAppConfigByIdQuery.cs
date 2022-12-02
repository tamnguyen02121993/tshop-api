using ErrorOr;
using MediatR;
using TShop.Contracts.AppConfig;

namespace TShop.Api.Features.AppConfigs.Queries.GetAppConfigById;

public class GetAppConfigByIdQuery: IRequest<ErrorOr<AppConfigResponse>>
{
    public int Id { get; set; }
}