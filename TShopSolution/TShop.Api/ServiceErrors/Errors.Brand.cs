using ErrorOr;

namespace TShop.Api.ServiceErrors;

public static partial class Errors
{
    public static class Brand
    {
        public static Error NotFound => Error.NotFound(
            code: "Brand.NotFound",
            description: "Brand not found"
        );
    }
}