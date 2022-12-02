using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using TShop.Contracts.Contact;
using TShop.Api.Repositories.Contacts;

namespace TShop.Api.Features.Contacts.Commands.CreateContact;

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ErrorOr<ContactResponse>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    public CreateContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<ContactResponse>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = _mapper.Map<Contact>(request);

        var createdContact = await _contactRepository.CreateContact(contact);

        if (createdContact is not null)
        {
            return _mapper.Map<ContactResponse>(createdContact);
        }

        return Errors.Contact.NotFound;
    }
}