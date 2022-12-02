using TShop.Api.Models;

namespace TShop.Api.Repositories.Products;

public interface IProductRepository
{
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(Product product);

    Task<Product?> GetProductById(Guid id);
    IQueryable<Product> GetAllProducts();
    IQueryable<Product> GetAvailableProducts();
}
