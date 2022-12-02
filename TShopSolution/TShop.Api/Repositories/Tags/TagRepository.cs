using Microsoft.EntityFrameworkCore;
using TShop.Api.EF;
using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Repositories.Tags;

public class TagRepository : ITagRepository
{
    private readonly TShopDbContext _context;
    public TagRepository(TShopDbContext context)
    {
        _context = context;
    }
    public async Task<Tag> CreateTag(Tag tag)
    {
        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task DeleteTag(Tag tag)
    {
        _context.Remove(tag);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Tag> GetAllTags()
    {
        return _context.Tags.AsNoTracking();
    }

    public async Task<Pagination<Tag>> GetAllTags(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Tags.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Title.ToLower().Contains(search.ToLower()));
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Tags.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Tag>
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

    public IQueryable<Tag> GetAvailableTags()
    {
        return _context.Tags.Where(x => x.Status == Status.ACTIVE).AsNoTracking();
    }

    public async Task<Pagination<Tag>> GetAvailableTags(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Tags.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Status == Status.ACTIVE && x.Title.ToLower().Contains(search.ToLower()));
        }
        else
        {
            query = query.Where(x => x.Status == Status.ACTIVE);
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Tags.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Tag>
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

    public async Task<Tag?> GetTagById(int id)
    {
        return await _context.Tags.FindAsync(id);
    }

    public async Task<Tag[]> GetTagByIds(List<int>? ids)
    {
        if (ids is null)
        {
            return new Tag[0];
        }
        return await _context.Tags.Where(x => ids.Any(y => y == x.Id)).ToArrayAsync();
    }

    public async Task<Tag> UpdateTag(Tag tag)
    {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();
        return tag;
    }
}