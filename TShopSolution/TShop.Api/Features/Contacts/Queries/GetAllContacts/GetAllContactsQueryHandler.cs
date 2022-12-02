using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Contacts;
using TShop.Contracts.Contact;

namespace TShop.Api.Features.Contacts.Queries.GetAllContacts;

public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactResponse>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    public GetAllContactsQueryHandler(IContactRepository contactRepository, IMapper mapper)
    {
        _mapper = mapper;
        _contactRepository = contactRepository;
    }
    public async Task<List<ContactResponse>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        var contacts = await _contactRepository.GetAllContacts().ToListAsync();
        return _mapper.Map<List<ContactResponse>>(contacts); 
    }
}