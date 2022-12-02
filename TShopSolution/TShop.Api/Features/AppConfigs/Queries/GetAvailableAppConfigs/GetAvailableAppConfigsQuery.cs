using MediatR;
using TShop.Contracts.AppConfig;

namespace TShop.Api.Features.AppConfigs.Queries.GetAvailableAppConfigs;

public class GetAvailableAppConfigsQuery: IRequest<List<AppConfigResponse>>
{
    
}