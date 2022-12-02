using TShop.Api.Models;

namespace TShop.Api.Repositories.AppConfigs;

public interface IAppConfigRepository
{
    Task<AppConfig> CreateAppConfig(AppConfig appConfig);
    Task<AppConfig> UpdateAppConfig(AppConfig appConfig);
    Task DeleteAppConfig(AppConfig appConfig);

    Task<AppConfig?> GetAppConfigById(int id);
    IQueryable<AppConfig> GetAllAppConfigs();
    IQueryable<AppConfig> GetAvailableAppConfigs();
}