using MediatR;
using TShop.Api.Repositories.Categories;
using TShop.Contracts.Category;
using MapsterMapper;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Categories.Queries.GetAvailableCategoriesPagination;

public class GetAvailableCategoriesPaginationQueryHandler : IRequestHandler<GetAvailableCategoriesPaginationQuery, Pagination<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public GetAvailableCategoriesPaginationQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<CategoryResponse>> Handle(GetAvailableCategoriesPaginationQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAvailableCategories(request.PageIndex, request.PageSize, request.Search);
        return _mapper.Map<Pagination<CategoryResponse>>(categories);
    }
}
