using CookBlog.Core.Entities;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Repositories;

public interface ITagRepository
{
    Task AddAsync(Tag tag);
    Task<Tag?> GetAsync(TagId id);
    Task<TagDtoo?> GetByIdForRedisAsync(Guid id);
    void DeleteAsync(Tag tag);
    Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> ids);
}
