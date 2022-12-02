using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Contact;

public record CreateContactRequest(
        string Email,
        string PhoneNumber,
        string Content,
        ContactStatus Status
);
