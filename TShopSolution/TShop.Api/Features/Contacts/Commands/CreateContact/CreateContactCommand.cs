using ErrorOr;
using MediatR;
using TShop.Contracts.Contact;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Contacts.Commands.CreateContact;

public class CreateContactCommand: IRequest<ErrorOr<ContactResponse>>
{
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public ContactStatus Status { get; set; }
}