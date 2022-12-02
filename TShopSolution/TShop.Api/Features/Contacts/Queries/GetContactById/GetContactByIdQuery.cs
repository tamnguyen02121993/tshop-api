using ErrorOr;
using MediatR;
using TShop.Contracts.Contact;

namespace TShop.Api.Features.Contacts.Queries.GetContactById;

public class GetContactByIdQuery: IRequest<ErrorOr<ContactResponse>>
{
    public Guid Id { get; set; }
}