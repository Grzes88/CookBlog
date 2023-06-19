using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Infrastructure.DAL.Repositories;

internal sealed class InMemoryCategoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories;
    public InMemoryCategoryRepository()
    {
        _categories = new List<Category>
        {
            Category.Create(Guid.NewGuid(), $"Fruits"),
            Category.Create(Guid.NewGuid(), $"Vegetables"),
            Category.Create(Guid.NewGuid(), $"Sweet"),
            Category.Create(Guid.NewGuid(), $"Cake"),
        };
    }

    public Task AddAsync(Category category)
    {
        _categories.Add(category);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(CategoryId id)
    {
        var category = _categories.SingleOrDefault(x => x.Id == id);
        _categories.Remove(category);

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _categories;
    }

    public async Task<Category> GetAsync(CategoryId id)
    {
        await Task.CompletedTask;
        return _categories.SingleOrDefault(x => x.Id == id);
    }

    public Task UpdateAsync(Category category)
    {
        return Task.CompletedTask;
    }
}
