using CookBlog.Core.Entities;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Repositories;

public interface ICommentRepository
{
    Task AddAsync(Comment comment);
    void DeleteAsync(Comment comment);
    Task<Comment?> GetAsync(CommentId id);
}
