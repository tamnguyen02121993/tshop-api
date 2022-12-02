using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Contacts;
using TShop.Contracts.Contact;
using TShop.Api.ServiceErrors;
using MapsterMapper;

namespace TShop.Api.Features.Contacts.Queries.GetContactById;

public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ErrorOr<ContactResponse>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    public GetContactByIdQueryHandler(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<ContactResponse>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetContactById(request.Id);
        if (contact is not null)
        {
            return _mapper.Map<ContactResponse>(contact);
        }

        return Errors.Contact.NotFound;
    }
}