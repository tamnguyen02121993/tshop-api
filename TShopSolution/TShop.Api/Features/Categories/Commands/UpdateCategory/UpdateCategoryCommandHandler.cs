using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using TShop.Api.Models;
using TShop.Api.Repositories.Categories;
using TShop.Api.ServiceErrors;
using TShop.Api.Utils.Extensions;
using TShop.Contracts.Category;

namespace TShop.Api.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<CategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryById(request.Id);
        if (category is null)
        {
            return Errors.Category.NotFound;
        }

        var updatedCategory = _mapper.Map<UpdateCategoryCommand, Category>(request, category);
        updatedCategory.SeoUrl = updatedCategory.Name.CreateSlugString();
        await _categoryRepository.UpdateCategory(updatedCategory);

        return _mapper.Map<CategoryResponse>(updatedCategory);
    }
}
