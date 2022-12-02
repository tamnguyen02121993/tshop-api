using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Repositories.Tags;

public interface ITagRepository
{
    Task<Tag> CreateTag(Tag tag);
    Task<Tag> UpdateTag(Tag tag);
    Task DeleteTag(Tag tag);

    Task<Tag?> GetTagById(int id);
    Task<Tag[]> GetTagByIds(List<int>? ids);
    IQueryable<Tag> GetAllTags();
    Task<Pagination<Tag>> GetAllTags(int pageIndex, int pageSize, string? search);
    IQueryable<Tag> GetAvailableTags();
    Task<Pagination<Tag>> GetAvailableTags(int pageIndex, int pageSize, string? search);
}