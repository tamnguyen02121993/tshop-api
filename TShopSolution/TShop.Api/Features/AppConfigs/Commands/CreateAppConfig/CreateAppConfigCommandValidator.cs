using FluentValidation;

namespace TShop.Api.Features.AppConfigs.Commands.CreateAppConfig;

public class CreateAppConfigCommandValidator: AbstractValidator<CreateAppConfigCommand>
{
    public CreateAppConfigCommandValidator()
    {
        RuleFor(x => x.Key).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Value).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Status).IsInEnum();
    }
}