using ErrorOr;
using MediatR;
using TShop.Api.Repositories.AppConfigs;
using TShop.Contracts.AppConfig;
using TShop.Api.ServiceErrors;
using MapsterMapper;

namespace TShop.Api.Features.AppConfigs.Queries.GetAppConfigById;

public class GetAppConfigByIdQueryHandler : IRequestHandler<GetAppConfigByIdQuery, ErrorOr<AppConfigResponse>>
{
    private readonly IAppConfigRepository _appConfigRepository;
    private readonly IMapper _mapper;
    public GetAppConfigByIdQueryHandler(IAppConfigRepository appConfigRepository, IMapper mapper)
    {
        _appConfigRepository = appConfigRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<AppConfigResponse>> Handle(GetAppConfigByIdQuery request, CancellationToken cancellationToken)
    {
        var appConfig = await _appConfigRepository.GetAppConfigById(request.Id);
        if (appConfig is not null)
        {
            return _mapper.Map<AppConfigResponse>(appConfig);
        }

        return Errors.AppConfig.NotFound;
    }
}