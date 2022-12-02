using ErrorOr;

namespace TShop.Api.ServiceErrors;

public static partial class Errors
{
    public static class AppConfig
    {
        public static Error NotFound => Error.NotFound(
            code: "AppConfig.NotFound",
            description: "AppConfig not found"
        );
    }
}