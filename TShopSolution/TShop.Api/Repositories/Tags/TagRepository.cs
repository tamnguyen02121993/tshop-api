using Microsoft.EntityFrameworkCore;
using TShop.Api.EF;
using TShop.Api.Models;
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
        return _context.Tags;
    }

    public IQueryable<Tag> GetAvailableTags()
    {
        return _context.Tags.Where(x => x.Status == Status.ACTIVE);
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