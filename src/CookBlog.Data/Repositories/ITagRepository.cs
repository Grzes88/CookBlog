using CookBlog.Core.Entities;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Repositories;

public interface ITagRepository
{
    Task AddAsync(Tag tag);
    Task<Tag?> GetAsync(TagId id);
    void DeleteAsync(Tag tag);
    Task<ICollection<Tag>> GetTags(ICollection<Guid> ids);
}
