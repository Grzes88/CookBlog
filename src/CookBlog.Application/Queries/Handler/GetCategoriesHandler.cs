using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Core.Repositories;

namespace CookBlog.Application.Queries.Handler;

public class GetCategoriesHandler : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesHandler(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query)
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories.Select(c => c.AsDto());
    }
}
