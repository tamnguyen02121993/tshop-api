using FluentValidation;

namespace TShop.Api.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommandValidator: AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Content).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Status).IsInEnum();
    }
}