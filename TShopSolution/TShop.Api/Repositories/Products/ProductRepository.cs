using Microsoft.EntityFrameworkCore;
using TShop.Api.EF;
using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;
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

    public async Task<Pagination<Product>> GetAllProducts(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Products
                            .Include(x => x.ProductTags)
                            .Include(x => x.Images)
                            .Include(x => x.Brand)
                            .Include(x => x.Category)
                            .Include(x => x.Comments)
                            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()));
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Products.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Product>
        {
            Data = data,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalRows = totalRows,
            TotalPages = totalPages,
            HasNext = pageIndex + 1 < totalPages,
            HasPrevious = pageIndex > 0
        };
    }

    public IQueryable<Product> GetAvailableProducts()
    {
        return _context.Products
               .Include(x => x.ProductTags)
               .Include(x => x.Images)
               .Include(x => x.Brand)
               .Include(x => x.Category)
               .Include(x => x.Comments)
               .Where(x => x.Status == Status.ACTIVE)
               .AsNoTracking();
    }

    public async Task<Pagination<Product>> GetAvailableProducts(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Products
                            .Include(x => x.ProductTags)
                            .Include(x => x.Images)
                            .Include(x => x.Brand)
                            .Include(x => x.Category)
                            .Include(x => x.Comments)
                            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Status == Status.ACTIVE && x.Name.ToLower().Contains(search.ToLower()));
        }
        else
        {
            query = query.Where(x => x.Status == Status.ACTIVE);
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Products.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Product>
        {
            Data = data,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalRows = totalRows,
            TotalPages = totalPages,
            HasNext = pageIndex + 1 < totalPages,
            HasPrevious = pageIndex > 0
        };
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
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
        return product;
    }
}
