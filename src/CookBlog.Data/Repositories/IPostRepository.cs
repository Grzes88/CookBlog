using CookBlog.Core.Entities;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Repositories;

public interface IPostRepository
{
    Task AddAsync(Post post);
    Task<Post?> GetAsync(PostId id);
    Task<bool> AnyAsync(PostId id);
    void DeleteAsync(Post post);
}
