using FluentValidation;

namespace TShop.Api.Features.Contacts.Commands.CreateContact;

public class CreateTagCommandValidator: AbstractValidator<CreateContactCommand>
{
    public CreateTagCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Content).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Status).IsInEnum();
    }
}