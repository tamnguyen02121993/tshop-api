using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.AppConfigs;
using TShop.Contracts.AppConfig;
using TShop.Api.ServiceErrors;
using TShop.Api.Models;

namespace TShop.Api.Features.AppConfigs.Commands.UpdateAppConfig;

public class UpdateAppConfigCommandHandler : IRequestHandler<UpdateAppConfigCommand, ErrorOr<AppConfigResponse>>
{
    private readonly IAppConfigRepository _appConfigRepository;
    private readonly IMapper _mapper;
    
    public UpdateAppConfigCommandHandler(IAppConfigRepository appConfigRepository, IMapper mapper)
    {
        _appConfigRepository = appConfigRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AppConfigResponse>> Handle(UpdateAppConfigCommand request, CancellationToken cancellationToken)
    {
        var appConfig = await _appConfigRepository.GetAppConfigById(request.Id);
        if (appConfig is null)
        {
            return Errors.AppConfig.NotFound;
        }

        var updatedAppConfig = _mapper.Map<UpdateAppConfigCommand, AppConfig>(request, appConfig);
        await _appConfigRepository.UpdateAppConfig(updatedAppConfig);

        return _mapper.Map<AppConfigResponse>(updatedAppConfig);
    }
}