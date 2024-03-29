﻿using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Repositories;

internal sealed class PostRepository : IPostRepository
{
    private readonly DbSet<Post> _posts;

    public PostRepository(MyCookBlogDbContext dbContext) 
        => _posts = dbContext.Posts;

    public async Task AddAsync(Post post)
    {
        await _posts.AddAsync(post);
    }

    public void DeleteAsync(Post post)
    {
        _posts.Remove(post);
    }

    public async Task<bool> AnyAsync(PostId id) 
        => await _posts.AnyAsync(p => p.Id == id);

    public async Task<Post?> GetAsync(PostId id)
        => await _posts
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .SingleOrDefaultAsync(p => p.Id == id);
}
