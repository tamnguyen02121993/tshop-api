using Microsoft.EntityFrameworkCore;
using TShop.Api.EF;
using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Repositories.Brands;

public class BrandRepository : IBrandRepository
{
    private readonly TShopDbContext _context;
    public BrandRepository(TShopDbContext context)
    {
        _context = context;
    }
    public async Task<Brand> CreateBrand(Brand brand)
    {
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();
        return brand;
    }

    public async Task DeleteBrand(Brand brand)
    {
        _context.Remove(brand);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Brand> GetAllBrands()
    {
        return _context.Brands.AsNoTracking();
    }

    public async Task<Pagination<Brand>> GetAllBrands(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Brands.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()));
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Brands.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Brand>
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

    public IQueryable<Brand> GetAvailableBrands()
    {
        return _context.Brands.AsNoTracking().Where(x => x.Status == Status.ACTIVE);
    }

    public async Task<Pagination<Brand>> GetAvailableBrands(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Brands.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Status == Status.ACTIVE && x.Name.ToLower().Contains(search.ToLower()));
        }
        else
        {
            query = query.Where(x => x.Status == Status.ACTIVE);
        }
        
        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Brands.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Brand>
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

    public async Task<Brand?> GetBrandById(int id)
    {
        return await _context.Brands.FindAsync(id);
    }

    public async Task<Brand> UpdateBrand(Brand brand)
    {
        _context.Brands.Update(brand);
        await _context.SaveChangesAsync();
        return brand;
    }
}