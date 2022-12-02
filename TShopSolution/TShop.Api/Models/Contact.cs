using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;

public class Contact : Auditable
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public ContactStatus Status { get; set; }
}