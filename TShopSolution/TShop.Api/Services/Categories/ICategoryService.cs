using TShop.Api.Models;
using ErrorOr;

namespace TShop.Api.Services.Categories;

public interface ICategoryService
{
    ErrorOr<Created> CreateCategory(Category category);
    ErrorOr<Deleted> DeleteCategory(int id);
    ErrorOr<Category> GetCategory(int id);
    ErrorOr<UpdatedCategoryResult> UpdateCategory(Category category);
}