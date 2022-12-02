using FluentValidation;

namespace TShop.Api.Features.Contacts.Queries.GetAvailableContactsPagination;

public class GetAllContactsPaginationQueryValidator : AbstractValidator<GetAvailableContactsPaginationQuery>
{
    public GetAllContactsPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
