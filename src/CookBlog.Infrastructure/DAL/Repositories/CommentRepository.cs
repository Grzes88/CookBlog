using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Repositories;

internal sealed class CommentRepository : ICommentRepository
{
    private readonly DbSet<Comment> _comments;

    public CommentRepository(MyCookBlogDbContext dbContext) 
        => _comments = dbContext.Comments;

    public async Task AddAsync(Comment comment)
    {
        await _comments.AddAsync(comment);
    }

    public void DeleteAsync(Comment comment)
    {
        _comments.Remove(comment);
    }

    public async Task<Comment?> GetAsync(CommentId id)
    {
        return await _comments.SingleOrDefaultAsync(x => x.Id == id);
    }
}
