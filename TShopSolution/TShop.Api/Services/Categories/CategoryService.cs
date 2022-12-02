using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using ErrorOr;

namespace TShop.Api.Services.Categories;

public class CategoryService : ICategoryService
{
    private static readonly Dictionary<int, Category> _categories = new Dictionary<int, Category>();

    public ErrorOr<Created> CreateCategory(Category category)
    {
        _categories.Add(category.Id, category);
        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteCategory(int id)
    {
        _categories.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Category> GetCategory(int id)
    {
        if (_categories.TryGetValue(id, out var category))
        {
            return category;
        }

        return Errors.Category.NotFound;
    }

    public ErrorOr<UpdatedCategoryResult> UpdateCategory(Category category)
    {
        var isNewlyCreated = !_categories.ContainsKey(category.Id);

        _categories[category.Id] = category;

        return new UpdatedCategoryResult(isNewlyCreated);
    }
}