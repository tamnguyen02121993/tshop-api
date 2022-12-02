using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TShop.Api.Features.AppConfigs.Commands.CreateAppConfig;
using TShop.Api.Features.AppConfigs.Commands.DeleteAppConfig;
using TShop.Api.Features.AppConfigs.Commands.UpdateAppConfig;
using TShop.Api.Features.AppConfigs.Queries.GetAllAppConfigs;
using TShop.Api.Features.AppConfigs.Queries.GetAvailableAppConfigs;
using TShop.Api.Features.AppConfigs.Queries.GetAppConfigById;
using TShop.Contracts.AppConfig;

namespace TShop.Api.Controllers;

public class AppConfigsController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    public AppConfigsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppConfig(CreateAppConfigRequest request)
    {
        ErrorOr<AppConfigResponse> createAppConfigResult = await _sender.Send(_mapper.Map<CreateAppConfigCommand>(request));

        return createAppConfigResult.Match(
            appConfig => CreatedAtAction(nameof(GetAppConfigById), new {id = appConfig.Id}, appConfig),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAppConfigById([FromRoute]int id)
    {
        ErrorOr<AppConfigResponse> getAppConfigResult = await _sender.Send(new GetAppConfigByIdQuery
        {
            Id = id,
        });

        return getAppConfigResult.Match(
            appConfig => Ok(appConfig),
            errors => Problem(errors)
        );
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAppConfigs()
    {
        List<AppConfigResponse> appConfigs = await _sender.Send(new GetAllAppConfigsQuery());

        return Ok(appConfigs);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableAppConfigs()
    {
        List<AppConfigResponse> appConfigs = await _sender.Send(new GetAvailableAppConfigsQuery());

        return Ok(appConfigs);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateAppConfigRequest request)
    {
        ErrorOr<AppConfigResponse> updateAppConfigResult = await _sender.Send(_mapper.Map<UpdateAppConfigCommand>(request));

        return updateAppConfigResult.Match(
            appConfig => Ok(appConfig),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        ErrorOr<Deleted> deleteAppConfigResult = await _sender.Send(new DeleteAppConfigCommand()
        {
            Id = id
        });
        return deleteAppConfigResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
}