using ErrorOr;

namespace TShop.Api.ServiceErrors;

public static partial class Errors
{
    public static class Category
    {
        public static Error NotFound => Error.NotFound(
            code: "Category.NotFound",
            description: "Category not found"
        );
    }
}