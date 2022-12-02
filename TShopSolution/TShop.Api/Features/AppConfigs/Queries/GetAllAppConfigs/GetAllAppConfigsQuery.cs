using MediatR;
using TShop.Contracts.AppConfig;

namespace TShop.Api.Features.AppConfigs.Queries.GetAllAppConfigs;

public class GetAllAppConfigsQuery: IRequest<List<AppConfigResponse>>
{
    
}