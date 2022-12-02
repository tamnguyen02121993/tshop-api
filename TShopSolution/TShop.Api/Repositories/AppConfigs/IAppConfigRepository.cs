using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Repositories.AppConfigs;

public interface IAppConfigRepository
{
    Task<AppConfig> CreateAppConfig(AppConfig appConfig);
    Task<AppConfig> UpdateAppConfig(AppConfig appConfig);
    Task DeleteAppConfig(AppConfig appConfig);

    Task<AppConfig?> GetAppConfigById(int id);
    IQueryable<AppConfig> GetAllAppConfigs();
    Task<Pagination<AppConfig>> GetAllAppConfigs(int pageIndex, int pageSize, string? search);
    IQueryable<AppConfig> GetAvailableAppConfigs();
    Task<Pagination<AppConfig>> GetAvailableAppConfigs(int pageIndex, int pageSize, string? search);
}