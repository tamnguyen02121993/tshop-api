using MediatR;
using TShop.Contracts.Contact;

namespace TShop.Api.Features.Contacts.Queries.GetAvailableContacts;

public class GetAvailableContactsQuery: IRequest<List<ContactResponse>>
{
    
}