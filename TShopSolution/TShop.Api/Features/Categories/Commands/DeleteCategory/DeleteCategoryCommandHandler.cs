using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Categories;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<Deleted>>
{
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryById(request.Id);
        if (category is null)
        {
            return Errors.Category.NotFound;
        }
        await _categoryRepository.DeleteCategory(category);

        return Result.Deleted;
    }
}
