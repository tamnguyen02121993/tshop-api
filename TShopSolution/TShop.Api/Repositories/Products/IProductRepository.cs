using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Repositories.Products;

public interface IProductRepository
{
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(Product product);

    Task<Product?> GetProductById(Guid id);
    IQueryable<Product> GetAllProducts();
    Task<Pagination<Product>> GetAllProducts(int pageIndex, int pageSize, string? search);
    IQueryable<Product> GetAvailableProducts();
    Task<Pagination<Product>> GetAvailableProducts(int pageIndex, int pageSize, string? search);
}
