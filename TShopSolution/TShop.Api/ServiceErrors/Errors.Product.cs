using ErrorOr;

namespace TShop.Api.ServiceErrors;

public static partial class Errors
{
    public static class Product
    {
        public static Error NotFound => Error.NotFound(
            code: "Product.NotFound",
            description: "Product not found"
        );
    }
}