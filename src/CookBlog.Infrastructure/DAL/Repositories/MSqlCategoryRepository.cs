using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Repositories;

internal sealed class MSqlCategoryRepository : ICategoryRepository
{
    private readonly DbSet<Category> _categories;

    public MSqlCategoryRepository(MyCookBlogDbContext dbContext)
    {
        _categories = dbContext.Categories;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categories.Include(c => c.Posts).ToListAsync();
    }

    public async Task<Category> GetAsync(CategoryId id)
    {
        return await _categories.Include(c => c.Posts).SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Category category)
    {
        await _categories.AddAsync(category);
    }

    public Task UpdateAsync(Category category)
    {
        _categories.Update(category);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(CategoryId id)
    {
        var category = await _categories.SingleOrDefaultAsync(x => x.Id == id);
        _categories.Remove(category);
    }
}
