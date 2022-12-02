using ErrorOr;
using MediatR;
using TShop.Contracts.Contact;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommand: IRequest<ErrorOr<ContactResponse>>
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public ContactStatus Status { get; set; }
}