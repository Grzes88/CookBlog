using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Queries.Handler;

public class GetCategoryHandler : IQueryHandler<GetCategory, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> HandleAsync(GetCategory query)
    {
        var categoryId = new CategoryId(query.CategoryId);
        var category = await _categoryRepository.GetAsync(categoryId);

        if (category is null) 
        {
            throw new CategoryNotFoundException();
        }

        return category.AsDto();
    } 
}
