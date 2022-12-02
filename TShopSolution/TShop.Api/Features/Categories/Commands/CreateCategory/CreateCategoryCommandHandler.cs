using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Models;
using TShop.Api.Repositories.Categories;
using TShop.Api.ServiceErrors;
using TShop.Api.Utils.Extensions;
using TShop.Contracts.Category;

namespace TShop.Api.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<CategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);

        category.SeoUrl = category.Name.CreateSlugString();

        var createdCategory = await _categoryRepository.CreateCategory(category);

        if (createdCategory is not null)
        {
            return _mapper.Map<CategoryResponse>(createdCategory);
        }

        return Errors.Category.NotFound;
    }
}
