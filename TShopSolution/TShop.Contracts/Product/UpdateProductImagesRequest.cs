namespace TShop.Contracts.Product;

public record UpdateProductImagesRequest(
    List<ProductImageRequest> Images,
    Guid Id
);