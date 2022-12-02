using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.AppConfigs;
using TShop.Contracts.AppConfig;

namespace TShop.Api.Features.AppConfigs.Queries.GetAvailableAppConfigs;

public class GetAvailableAppConfigsQueryHandler : IRequestHandler<GetAvailableAppConfigsQuery, List<AppConfigResponse>>
{
    private readonly IAppConfigRepository _appConfigRepository;
    private readonly IMapper _mapper;
    public GetAvailableAppConfigsQueryHandler(IAppConfigRepository appConfigRepository, IMapper mapper)
    {
        _mapper = mapper;
        _appConfigRepository = appConfigRepository;
    }
    public async Task<List<AppConfigResponse>> Handle(GetAvailableAppConfigsQuery request, CancellationToken cancellationToken)
    {
        var appConfigs = await _appConfigRepository.GetAvailableAppConfigs().ToListAsync();
        return _mapper.Map<List<AppConfigResponse>>(appConfigs); 
    }
}