using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TShop.Api.Features.Contacts.Commands.CreateContact;
using TShop.Api.Features.Contacts.Commands.DeleteContact;
using TShop.Api.Features.Contacts.Commands.UpdateContact;
using TShop.Api.Features.Contacts.Queries.GetAllContacts;
using TShop.Api.Features.Contacts.Queries.GetAvailableContacts;
using TShop.Api.Features.Contacts.Queries.GetContactById;
using TShop.Contracts.Contact;

namespace TShop.Api.Controllers;

public class ContactsController: ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    public ContactsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactRequest request)
    {
        ErrorOr<ContactResponse> createContactResult = await _sender.Send(_mapper.Map<CreateContactCommand>(request));

        return createContactResult.Match(
            contact => CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetContactById([FromRoute] Guid id)
    {
        ErrorOr<ContactResponse> getContactResult = await _sender.Send(new GetContactByIdQuery
        {
            Id = id,
        });

        return getContactResult.Match(
            contact => Ok(contact),
            errors => Problem(errors)
        );
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllContacts()
    {
        List<ContactResponse> contacts = await _sender.Send(new GetAllContactsQuery());

        return Ok(contacts);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableContacts()
    {
        List<ContactResponse> contacts = await _sender.Send(new GetAvailableContactsQuery());

        return Ok(contacts);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateContact([FromBody] UpdateContactRequest request)
    {
        ErrorOr<ContactResponse> updateContactResult = await _sender.Send(_mapper.Map<UpdateContactCommand>(request));

        return updateContactResult.Match(
            contact => Ok(contact),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
    {
        ErrorOr<Deleted> deleteContactResult = await _sender.Send(new DeleteContactCommand()
        {
            Id = id
        });
        return deleteContactResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
}
