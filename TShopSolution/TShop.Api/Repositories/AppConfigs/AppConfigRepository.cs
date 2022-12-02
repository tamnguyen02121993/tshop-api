using Microsoft.EntityFrameworkCore;
using TShop.Api.EF;
using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;
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
        return _context.AppConfigs.AsNoTracking();
    }

    public IQueryable<AppConfig> GetAvailableAppConfigs()
    {
        return _context.AppConfigs.Where(x => x.Status == Status.ACTIVE).AsNoTracking();
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

    public async Task<Pagination<AppConfig>> GetAllAppConfigs(int pageIndex, int pageSize, string? search)
    {
        var query = _context.AppConfigs.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Key.ToLower().Contains(search.ToLower()) || x.Value.ToLower().Contains(search.ToLower()));
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.AppConfigs.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<AppConfig>
        {
            Data = data,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalRows = totalRows,
            TotalPages = totalPages,
            HasNext = pageIndex + 1 < totalPages,
            HasPrevious = pageIndex > 0
        };
    }

    public async Task<Pagination<AppConfig>> GetAvailableAppConfigs(int pageIndex, int pageSize, string? search)
    {
        var query = _context.AppConfigs.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Status == Status.ACTIVE && (x.Key.ToLower().Contains(search.ToLower()) || x.Value.ToLower().Contains(search.ToLower())));
        }
        else
        {
            query = query.Where(x => x.Status == Status.ACTIVE);
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.AppConfigs.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<AppConfig>
        {
            Data = data,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalRows = totalRows,
            TotalPages = totalPages,
            HasNext = pageIndex + 1 < totalPages,
            HasPrevious = pageIndex > 0
        };
    }
}