using TShop.Api.EF;
using TShop.Api.Models;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Repositories.AppConfigs;

public class AppConfigRepository : IAppConfigRepository
{
    private readonly TShopDbContext _context;
    public AppConfigRepository(TShopDbContext context)
    {
        _context = context;
    }
    public async Task<AppConfig> CreateAppConfig(AppConfig appConfig)
    {
        await _context.AppConfigs.AddAsync(appConfig);
        await _context.SaveChangesAsync();
        return appConfig;
    }

    public async Task DeleteAppConfig(AppConfig appConfig)
    {
        _context.Remove(appConfig);
        await _context.SaveChangesAsync();
    }

    public IQueryable<AppConfig> GetAllAppConfigs()
    {
        return _context.AppConfigs;
    }

    public IQueryable<AppConfig> GetAvailableAppConfigs()
    {
        return _context.AppConfigs.Where(x => x.Status == Status.ACTIVE);
    }

    public async Task<AppConfig?> GetAppConfigById(int id)
    {
        return await _context.AppConfigs.FindAsync(id);
    }

    public async Task<AppConfig> UpdateAppConfig(AppConfig appConfig)
    {
        _context.AppConfigs.Update(appConfig);
        await _context.SaveChangesAsync();
        return appConfig;
    }
}