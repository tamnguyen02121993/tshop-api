using ErrorOr;
using MediatR;

namespace TShop.Api.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand: IRequest<ErrorOr<Deleted>>
    {
        public Guid Id { get; set; }
    }
}
