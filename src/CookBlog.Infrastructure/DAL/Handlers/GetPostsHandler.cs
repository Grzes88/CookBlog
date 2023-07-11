using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Handlers;

public sealed class GetPostsHandler : IQueryHandler<GetPosts, IEnumerable<PostDto>>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetPostsHandler(MyCookBlogDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<PostDto>> HandleAsync(GetPosts query)
        => await _dbContext.Posts
            .AsNoTracking()
            .Select(Extensions.AsPostDto())
            .ToListAsync();
}
