using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Exceptions;
using CookBlog.Application.Queries;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Handlers;

public sealed class GetTagHandler : IQueryHandler<GetTag, TagDto>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetTagHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<TagDto> HandleAsync(GetTag query)
    {
        var tagId = new TagId(query.TagId);
        var tag = await _dbContext.Tags
            .AsNoTracking()
            .Select(Extensions.AsTagDto())
            .SingleOrDefaultAsync(x => x.Id == tagId.Value);

        if (tag is null) 
        {
            throw new NotFoundTagException(tagId);
        }

        return tag;
    }
}
