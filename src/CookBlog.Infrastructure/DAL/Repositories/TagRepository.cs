using CookBlog.Core;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Repositories;

internal sealed class TagRepository : ITagRepository
{
    private readonly DbSet<Tag> _tags;

    public TagRepository(MyCookBlogDbContext dbContext)
        => _tags = dbContext.Tags;

    public async Task AddAsync(Tag tag)
    {
        await _tags.AddAsync(tag);
    }

    public void DeleteAsync(Tag tag)
    {
        _tags.Remove(tag);
    }

    public async Task<Tag?> GetAsync(TagId id)
        => await _tags
        .Include(t => t.Posts)
        .SingleOrDefaultAsync(t => t.Id == id);

    public async Task<TagDtoo?> GetByIdForRedisAsync(Guid id)
    {
        var tagId = new TagId(id);
        var tag = await _tags.SingleOrDefaultAsync(x => x.Id == tagId);

        return new TagDtoo { Id = tag.Id, Description = tag.Description };
    }

    public async Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> ids)
    {
        var tag = await _tags.Where(t => ids.Contains(t.Id)).ToListAsync();
        return tag;
    }
}
