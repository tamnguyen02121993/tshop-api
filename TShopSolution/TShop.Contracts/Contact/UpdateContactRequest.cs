using TShop.Contracts.Utils.Enums;

namespace TShop.Contracts.Contact;

public record UpdateContactRequest(
    Guid Id,
    string Email,
    string PhoneNumber,
    string Content,
    ContactStatus Status
);