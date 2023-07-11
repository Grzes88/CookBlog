using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Handlers;

public sealed class GetCategoriesHandler : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetCategoriesHandler(MyCookBlogDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query)
        => await _dbContext.Categories
            .AsNoTracking()
            .Select(Extensions.AsCategoryDto())
            .ToListAsync();
}
