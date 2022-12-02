using TShop.Api.Repositories.AppConfigs;
using TShop.Api.Repositories.Brands;
using TShop.Api.Repositories.Categories;
using TShop.Api.Repositories.Contacts;
using TShop.Api.Repositories.Products;
using TShop.Api.Repositories.Tags;

namespace TShop.Api.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IAppConfigRepository, AppConfigRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}