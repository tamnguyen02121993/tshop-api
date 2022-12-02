using Mapster;
using TShop.Api.Features.Contacts.Commands.CreateContact;
using TShop.Api.Features.Contacts.Commands.UpdateContact;
using TShop.Api.Models;
using TShop.Contracts.Contact;

namespace TShop.Api.Mappings;

public class ContactMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateContactRequest, CreateContactCommand>();
        config.NewConfig<UpdateContactRequest, UpdateContactCommand>().IgnoreNullValues(true);
        config.NewConfig<UpdateContactCommand, Contact>().IgnoreNullValues(true);
        config.NewConfig<Contact, ContactResponse>();
    }
}
