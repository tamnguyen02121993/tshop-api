using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Contacts;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.Contacts.Commands.DeleteContact;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ErrorOr<Deleted>>
{
    private readonly IContactRepository _contactRepository;
    public DeleteContactCommandHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetContactById(request.Id);
        if (contact is null)
        {
            return Errors.Contact.NotFound;
        }
        await _contactRepository.DeleteContact(contact);

        return Result.Deleted;
    }
}