using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Contacts;
using TShop.Contracts.Contact;
using TShop.Api.ServiceErrors;
using TShop.Api.Models;

namespace TShop.Api.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ErrorOr<ContactResponse>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    
    public UpdateContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ContactResponse>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetContactById(request.Id);
        if (contact is null)
        {
            return Errors.Contact.NotFound;
        }

        var updatedContact = _mapper.Map<UpdateContactCommand, Contact>(request, contact);
        await _contactRepository.UpdateContact(updatedContact);

        return _mapper.Map<ContactResponse>(updatedContact);
    }
}