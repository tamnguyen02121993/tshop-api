using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Categories;
using TShop.Contracts.Category;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Categories.Queries.GetAllCategoriesPagination;


public class GetAllCategoriesPaginationQueryHandler : IRequestHandler<GetAllCategoriesPaginationQuery, Pagination<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public GetAllCategoriesPaginationQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<CategoryResponse>> Handle(GetAllCategoriesPaginationQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllCategories(request.PageIndex, request.PageSize, request.Search);
        return _mapper.Map<Pagination<CategoryResponse>>(categories);
    }
}
