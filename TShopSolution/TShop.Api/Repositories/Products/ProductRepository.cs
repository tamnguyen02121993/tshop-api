using Microsoft.EntityFrameworkCore;
using TShop.Api.EF;
using TShop.Api.Models;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly TShopDbContext _context;
    public ProductRepository(TShopDbContext context)
    {
        _context = context;
    }
    public async Task<Product> CreateProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        //await _context.Entry(product).Collection(x => x.ProductTags).LoadAsync();
        return product;
    }

    public async Task DeleteProduct(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Product> GetAllProducts()
    {
        return _context.Products
                .Include(x => x.ProductTags)
                .Include(x => x.Images)
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.Comments)
                .AsNoTracking();

    }

    public IQueryable<Product> GetAvailableProducts()
    {
        return _context.Products
               .Include(x => x.ProductTags)
               //.ThenInclude(x =>x.Tag)
               .Include(x => x.Images)
               .Include(x => x.Brand)
               .Include(x => x.Category)
               .Include(x => x.Comments)
               .Where(x => x.Status == Status.ACTIVE)
               .AsNoTracking();
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if(product == null)
        {
            return null;
        }
        await _context.Entry(product).Collection(x => x.Images).LoadAsync();
        await _context.Entry(product).Collection(x => x.ProductTags).LoadAsync();
        return product;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        //await _context.Entry(product).Collection(x => x.ProductTags).LoadAsync();
        return product;
    }
}
