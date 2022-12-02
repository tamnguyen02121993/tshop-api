using MediatR;
using TShop.Contracts.Contact;

namespace TShop.Api.Features.Contacts.Queries.GetAllContacts;

public class GetAllContactsQuery: IRequest<List<ContactResponse>>
{
    
}