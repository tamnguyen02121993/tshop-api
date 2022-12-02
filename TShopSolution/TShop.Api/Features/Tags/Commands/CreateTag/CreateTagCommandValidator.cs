using FluentValidation;

namespace TShop.Api.Features.Tags.Commands.CreateTag;

public class CreateTagCommandValidator: AbstractValidator<CreateTagCommand>
{
    public CreateTagCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Status).IsInEnum();
    }
}