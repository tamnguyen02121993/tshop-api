using FluentValidation;

namespace TShop.Api.Features.Tags.Commands.UpdateTag;

public class UpdateTagCommandValidator: AbstractValidator<UpdateTagCommand>
{
    public UpdateTagCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Status).IsInEnum();
    }
}