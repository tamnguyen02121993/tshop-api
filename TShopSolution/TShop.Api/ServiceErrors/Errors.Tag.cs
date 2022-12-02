using ErrorOr;

namespace TShop.Api.ServiceErrors;

public static partial class Errors
{
    public static class Tag
    {
        public static Error NotFound => Error.NotFound(
            code: "Tag.NotFound",
            description: "Tag not found"
        );
    }
}