using ErrorOr;
using MediatR;
using TShop.Contracts.Product;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand: IRequest<ErrorOr<ProductResponse>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal? SalePrice { get; set; }
    public int Quantity { get; set; }
    public int Warranty { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public Status Status { get; set; }
    public bool IsNewProduct { get; set; }
    public bool IsFeaturedProduct { get; set; }
    public bool IsFavoriteProduct { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public List<int>? Tags { get; set; }
}
