using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.AppConfigs;
using TShop.Contracts.AppConfig;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.AppConfigs.Queries.GetAvailableAppConfigsPagination;

public class GetAvailableAppConfigsPaginationQueryHandler : IRequestHandler<GetAvailableAppConfigsPaginationQuery, Pagination<AppConfigResponse>>
{
    private readonly IAppConfigRepository _appConfigRepository;
    private readonly IMapper _mapper;
    public GetAvailableAppConfigsPaginationQueryHandler(IAppConfigRepository appConfigRepository, IMapper mapper)
    {
        _appConfigRepository = appConfigRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<AppConfigResponse>> Handle(GetAvailableAppConfigsPaginationQuery request, CancellationToken cancellationToken)
    {
        var appConfigs = await _appConfigRepository.GetAvailableAppConfigs(request.PageIndex, request.PageSize, request.Search);
        var appConfigsResponse = _mapper.Map<Pagination<AppConfigResponse>>(appConfigs);

        return appConfigsResponse;
    }
}
