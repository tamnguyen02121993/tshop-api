using TShop.Api.Models;

namespace TShop.Api.Repositories.Tags;

public interface ITagRepository
{
    Task<Tag> CreateTag(Tag tag);
    Task<Tag> UpdateTag(Tag tag);
    Task DeleteTag(Tag tag);

    Task<Tag?> GetTagById(int id);
    Task<Tag[]> GetTagByIds(List<int>? ids);
    IQueryable<Tag> GetAllTags();
    IQueryable<Tag> GetAvailableTags();
}