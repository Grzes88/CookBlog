using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using Microsoft.Extensions.Caching.Memory;

namespace CookBlog.Infrastructure.DAL.Repositories;

internal class CacheTagRepository : ITagRepository
{
    private readonly ITagRepository _decorated;
    private readonly IMemoryCache _memoryCache;

    public CacheTagRepository(ITagRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;
    }

    public async Task<Tag?> GetAsync(TagId id)
    {
        string key = $"tag-{id}";

        return await _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                return _decorated.GetAsync(id);
            });
    }

    public Task AddAsync(Tag tag) => _decorated.AddAsync(tag);

    public void DeleteAsync(Tag tag) => _decorated.DeleteAsync(tag);

    public async Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> ids) => await _decorated.GetTags(ids);
}
