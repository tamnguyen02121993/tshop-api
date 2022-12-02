using ErrorOr;
using MediatR;
using TShop.Contracts.Brand;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommand: IRequest<ErrorOr<BrandResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public Status Status { get; set; }
}