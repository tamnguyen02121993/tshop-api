using TShop.Contracts.Tag;
using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Product;

public record ProductResponse(
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
    List<ProductImageResponse> Images,
    List<int> Tags
);
