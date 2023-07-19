using CookBlog.Core;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CookBlog.Infrastructure.DAL.Repositories;

internal class CacheTagRepository : ITagRepository
{
    private readonly ITagRepository _decorated;
    private readonly IDistributedCache _distributedCache;

    public CacheTagRepository(ITagRepository decorated, IDistributedCache distributedCache)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
    }

    public async Task<TagDtoo?> GetByIdForRedisAsync(Guid id)
    {
        string key = $"tag-{id}";

        string? cacheTag = await _distributedCache.GetStringAsync(key);

        TagDtoo? tagDto;
        if (string.IsNullOrEmpty(cacheTag))
        {
            tagDto = await _decorated.GetByIdForRedisAsync(id);

            if (tagDto is null)
            {
                return tagDto;
            }

            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(tagDto));

            return tagDto;
        }

        tagDto = JsonConvert.DeserializeObject<TagDtoo>(
            cacheTag,
            new JsonSerializerSettings
            {
                ConstructorHandling =
                    ConstructorHandling.AllowNonPublicDefaultConstructor
            });

        return tagDto;
    }

    public async Task<Tag?> GetAsync(TagId id) => await _decorated.GetAsync(id);

    public Task AddAsync(Tag tag) => _decorated.AddAsync(tag);

    public void DeleteAsync(Tag tag) => _decorated.DeleteAsync(tag);

    public async Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> ids) => await _decorated.GetTags(ids);
}
