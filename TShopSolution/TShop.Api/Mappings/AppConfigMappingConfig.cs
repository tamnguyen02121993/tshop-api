using Mapster;
using TShop.Api.Features.AppConfigs.Commands.CreateAppConfig;
using TShop.Api.Features.AppConfigs.Commands.UpdateAppConfig;
using TShop.Api.Features.Categories.Commands.UpdateCategory;
using TShop.Api.Models;
using TShop.Contracts.AppConfig;

namespace TShop.Api.Mappings;

public class AppConfigMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAppConfigRequest, CreateAppConfigCommand>();
        config.NewConfig<UpdateAppConfigRequest, UpdateAppConfigCommand>().IgnoreNullValues(true);
        config.NewConfig<UpdateAppConfigCommand, AppConfig>().IgnoreNullValues(true);
        config.NewConfig<AppConfig, AppConfigResponse>();
    }
}
