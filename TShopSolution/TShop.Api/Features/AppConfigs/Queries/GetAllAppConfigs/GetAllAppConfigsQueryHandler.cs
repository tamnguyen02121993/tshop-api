using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.AppConfigs;
using TShop.Contracts.AppConfig;

namespace TShop.Api.Features.AppConfigs.Queries.GetAllAppConfigs;

public class GetAllAppConfigsQueryHandler : IRequestHandler<GetAllAppConfigsQuery, List<AppConfigResponse>>
{
    private readonly IAppConfigRepository _appConfigRepository;
    private readonly IMapper _mapper;
    public GetAllAppConfigsQueryHandler(IAppConfigRepository appConfigRepository, IMapper mapper)
    {
        _mapper = mapper;
        _appConfigRepository = appConfigRepository;
    }
    public async Task<List<AppConfigResponse>> Handle(GetAllAppConfigsQuery request, CancellationToken cancellationToken)
    {
        var appConfigs = await _appConfigRepository.GetAllAppConfigs().ToListAsync();
        return _mapper.Map<List<AppConfigResponse>>(appConfigs); 
    }
}