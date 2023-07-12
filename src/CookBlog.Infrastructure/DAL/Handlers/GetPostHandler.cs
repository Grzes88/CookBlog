using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Exceptions;
using CookBlog.Application.Queries;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Handlers;

public sealed class GetPostHandler : IQueryHandler<GetPost, PostDto>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetPostHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<PostDto> HandleAsync(GetPost query)
    {
        var postId = new PostId(query.PostId);
        var post = await _dbContext.Posts
            .AsNoTracking()
            .Select(Extensions.AsPostDto())
            .SingleOrDefaultAsync(p => p.Id == postId.Value);

        if (post is null) 
        {
            throw new NotFoundPostException(postId);
        }

        return post;
    }
}
