using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Handlers;

public sealed class GetTagsHandler : IQueryHandler<GetTags, IEnumerable<TagDto>>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetTagsHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<IEnumerable<TagDto>> HandleAsync(GetTags query)
    {
        var tags = await _dbContext.Tags
            .Include(t => t.Posts)
            .AsNoTracking()
            .ToListAsync();

        return tags.Select(t => t.AsDto());
    }
}
