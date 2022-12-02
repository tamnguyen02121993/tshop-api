using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Categories;
using TShop.Api.ServiceErrors;
using TShop.Contracts.Category;

namespace TShop.Api.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ErrorOr<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public GetCategoryByIdQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<ErrorOr<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryById(request.Id);

        if (category is not null)
        {
            return _mapper.Map<CategoryResponse>(category);
        }

        return Errors.Category.NotFound;
    }
}
