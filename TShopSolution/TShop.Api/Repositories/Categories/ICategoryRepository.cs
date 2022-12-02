using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Repositories.Categories;

public interface ICategoryRepository
{
    Task<Category> CreateCategory(Category category);
    Task<Category> UpdateCategory(Category category);
    Task DeleteCategory(Category category);

    Task<Category?> GetCategoryById(int id);
    IQueryable<Category> GetAllCategories();
    Task<Pagination<Category>> GetAllCategories(int pageIndex, int pageSize, string? search);
    IQueryable<Category> GetAvailableCategories();
    Task<Pagination<Category>> GetAvailableCategories(int pageIndex, int pageSize, string? search);
}