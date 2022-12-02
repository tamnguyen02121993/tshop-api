using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using TShop.Contracts.AppConfig;
using TShop.Api.Repositories.AppConfigs;

namespace TShop.Api.Features.AppConfigs.Commands.CreateAppConfig;

public class CreateAppConfigCommandHandler : IRequestHandler<CreateAppConfigCommand, ErrorOr<AppConfigResponse>>
{
    private readonly IAppConfigRepository _appConfigRepository;
    private readonly IMapper _mapper;
    public CreateAppConfigCommandHandler(IAppConfigRepository appConfigRepository, IMapper mapper)
    {
        _appConfigRepository = appConfigRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<AppConfigResponse>> Handle(CreateAppConfigCommand request, CancellationToken cancellationToken)
    {
        var appConfig = _mapper.Map<AppConfig>(request);

        var createdAppConfig = await _appConfigRepository.CreateAppConfig(appConfig);

        if (createdAppConfig is not null)
        {
            return _mapper.Map<AppConfigResponse>(createdAppConfig);
        }

        return Errors.AppConfig.NotFound;
    }
}