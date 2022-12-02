
using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Product;

public record UpdateProductRequest(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    decimal? SalePrice,
    int Quantity,
    int Warranty,
    string ImageUrl,
    Status Status,
    bool IsNewProduct,
    bool IsFeaturedProduct,
    bool IsFavoriteProduct,
    int CategoryId,
    int BrandId,
    List<int>? Tags
);
