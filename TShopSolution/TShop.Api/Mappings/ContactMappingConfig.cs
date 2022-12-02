using Mapster;
using TShop.Api.Features.Contacts.Commands.CreateContact;
using TShop.Api.Features.Contacts.Commands.UpdateContact;
using TShop.Api.Models;
using TShop.Contracts.Contact;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Mappings;

public class ContactMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateContactRequest, CreateContactCommand>();
        config.NewConfig<UpdateContactRequest, UpdateContactCommand>().IgnoreNullValues(true);
        config.NewConfig<UpdateContactCommand, Contact>().IgnoreNullValues(true);
        config.NewConfig<Pagination<Contact>, Pagination<ContactResponse>>().IgnoreNullValues(true);
        config.NewConfig<Contact, ContactResponse>();
    }
}
