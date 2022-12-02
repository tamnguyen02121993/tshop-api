using ErrorOr;

namespace TShop.Api.ServiceErrors;

public static partial class Errors
{
    public static class Contact
    {
        public static Error NotFound => Error.NotFound(
            code: "Contact.NotFound",
            description: "Contact not found"
        );
    }
}