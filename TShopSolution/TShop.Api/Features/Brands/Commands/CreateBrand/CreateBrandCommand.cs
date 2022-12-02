using ErrorOr;
using MediatR;
using TShop.Contracts.Brand;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand: IRequest<ErrorOr<BrandResponse>>
{
    public string Name { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public Status Status { get; set; }
}