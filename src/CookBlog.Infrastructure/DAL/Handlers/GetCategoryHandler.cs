using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Exceptions;
using CookBlog.Application.Queries;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Handlers;

internal sealed class GetCategoryHandler : IQueryHandler<GetCategory, CategoryDto>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetCategoryHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<CategoryDto> HandleAsync(GetCategory query)
    {
        var categoryId = new CategoryId (query.CategoryId);
        var category = await _dbContext.Categories
            .AsNoTracking()
            .Select(Extensions.AsCategoryDto())
            .SingleOrDefaultAsync(c => c.Id == categoryId.Value);

        if (category is null) 
        {
            throw new NotFoundCategoryException(categoryId);
        }

        return category;
    }
}
