using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;

public class Product: Auditable
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SeoUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? SalePrice { get; set; }
    public int Quantity { get; set; }
    public int Warranty { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public Status Status { get; set; }
    public bool IsNewProduct { get; set; }
    public bool IsFeaturedProduct { get; set; }
    public bool IsFavoriteProduct { get; set; }
    public int Viewed { get; set; }
    public float Rating { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }


    public ICollection<ProductImages> Images { get; set; } = new List<ProductImages>();
    public Category Category { get; set; } = new Category();
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public Brand Brand { get; set; } = new Brand();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
}