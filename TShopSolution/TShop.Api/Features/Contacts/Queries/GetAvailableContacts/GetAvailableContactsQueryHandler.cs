using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Contacts;
using TShop.Contracts.Contact;

namespace TShop.Api.Features.Contacts.Queries.GetAvailableContacts;

public class GetAvailableContactsQueryHandler : IRequestHandler<GetAvailableContactsQuery, List<ContactResponse>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    public GetAvailableContactsQueryHandler(IContactRepository contactRepository, IMapper mapper)
    {
        _mapper = mapper;
        _contactRepository = contactRepository;
    }
    public async Task<List<ContactResponse>> Handle(GetAvailableContactsQuery request, CancellationToken cancellationToken)
    {
        var contacts = await _contactRepository.GetAvailableContacts().ToListAsync();
        return _mapper.Map<List<ContactResponse>>(contacts); 
    }
}