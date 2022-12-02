using Microsoft.EntityFrameworkCore;
using TShop.Api.EF;
using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly TShopDbContext _context;

    public CategoryRepository(TShopDbContext context)
    {
        _context = context;
    }

    public async Task<Category> CreateCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task DeleteCategory(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Category> GetAllCategories()
    {
        return _context.Categories.AsNoTracking();
    }

    public async Task<Pagination<Category>> GetAllCategories(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Categories.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()));
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Brands.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Category>
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

    public IQueryable<Category> GetAvailableCategories()
    {
        return _context.Categories.Where(x => x.Status == Status.ACTIVE).AsNoTracking();
    }

    public async Task<Pagination<Category>> GetAvailableCategories(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Categories.AsNoTracking();
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

        return new Pagination<Category>
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

    public async Task<Category?> GetCategoryById(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }
}

