using Mapster;
using TShop.Api.Features.Categories.Commands.CreateCategory;
using TShop.Api.Features.Categories.Commands.UpdateCategory;
using TShop.Api.Models;
using TShop.Contracts.Brand;
using TShop.Contracts.Category;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Mappings;

public class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCategoryRequest, CreateCategoryCommand>();
        config.NewConfig<UpdateCategoryRequest, UpdateCategoryCommand>().IgnoreNullValues(true);
        config.NewConfig<UpdateCategoryCommand, Category>().IgnoreNullValues(true);
        config.NewConfig<Pagination<Category>, Pagination<CategoryResponse>>().IgnoreNullValues(true);
        config.NewConfig<Category, CategoryResponse>();
    }
}